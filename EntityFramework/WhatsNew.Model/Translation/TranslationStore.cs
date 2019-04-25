using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Model.Translation
{
    public class TranslationStore
    {
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, object>> _store = new ConcurrentDictionary<string, ConcurrentDictionary<string, object>>();

        public TValue Get<TValue>(string property, string language = null)
        {
            return (TValue)Get(property, language);
        }

        public object Get(string property, string language = null)
        {
            if (language == null)
            {
                language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            }

            var prop = _store.GetOrAdd(property, p => new ConcurrentDictionary<string, object>());
            object value;
            if (prop.TryGetValue(property, out value))
            {
                return value;
            }
            return null;
        }

        public IEnumerable<TranslationStoreItem> GetItems()
        {
            return (from p in _store
                    from l in p.Value
                    select new TranslationStoreItem(p.Key, l.Key, l.Value)
                    ).ToList();
        }

        public void Set<TValue>(string property, TValue value, params string[] language)
        {
            Set(property, (object)value, language);
        }

        public void Set(string property, object value, params string[] language)
        {
            if (!language.Any())
            {
                language = new[] { CultureInfo.CurrentCulture.TwoLetterISOLanguageName };
            }

            var prop = _store.GetOrAdd(property, p => new ConcurrentDictionary<string, object>());
            foreach (var lang in language)
            {
                prop.AddOrUpdate(lang, p => value, (p, q) => value);
            }
        }

        public class TranslationStoreItem
        {
            public TranslationStoreItem(string property, string language, object value)
            {
                Property = property;
                Language = language;
                Value = value;
            }

            public string Language { get; }

            public string Property { get; }

            public object Value { get; }
        }
    }
}