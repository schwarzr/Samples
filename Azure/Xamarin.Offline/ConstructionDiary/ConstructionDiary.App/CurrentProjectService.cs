using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using ConstructionDiary.Model;

namespace ConstructionDiary.App
{
    public class CurrentProjectService : ICurrentProjectService
    {
        private readonly ConcurrentDictionary<object, Action<ProjectInfo>> _registrations = new ConcurrentDictionary<object, Action<ProjectInfo>>();

        public ProjectInfo Current { get; private set; }

        public void Change(ProjectInfo project)
        {
            Current = project;

            foreach (var item in _registrations.Values)
            {
                item(project);
            }
        }

        public IDisposable Register(Action<ProjectInfo> register)
        {
            var key = new object();

            _registrations.AddOrUpdate(key, register, (p, q) => register);

            return new Subscription(key, this);
        }

        private class Subscription : IDisposable
        {
            private CurrentProjectService _currentProjectService;

            private object _key;

            public Subscription(object key, CurrentProjectService currentProjectService)
            {
                this._key = key;
                this._currentProjectService = currentProjectService;
            }

            public void Dispose()
            {
                _currentProjectService._registrations.TryRemove(_key, out var value);
            }
        }
    }
}