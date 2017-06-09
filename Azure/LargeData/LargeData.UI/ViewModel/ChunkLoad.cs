using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LargeData.Model.Custom;

namespace LargeData.UI.ViewModel
{
    internal class ChunkLoad<TItem> : IProgress<TItem>
    {
        private readonly List<TItem> _buffer;
        private readonly int _chunkSize;
        private readonly ObservableCollection<TItem> _items;
        private int _count;

        public ChunkLoad(ObservableCollection<TItem> items, int chunkSize = 100)
        {
            this._items = items;
            this._buffer = new List<TItem>();
            _chunkSize = chunkSize;
        }

        public void Report(TItem value)
        {
            _buffer.Add(value);
            if (_buffer.Count >= _chunkSize)
            {
                foreach (var item in this._buffer)
                {
                    _items.Add(item);
                }
                _buffer.Clear();
            }
        }

        internal void Complete()
        {
            foreach (var item in this._buffer)
            {
                _items.Add(item);
            }
        }
    }
}