using GameEngine.Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class MemoryStorage : IDataStorage
    {
        private static Hashtable _hashtable;

        public MemoryStorage()
        {
            if (_hashtable == null)
                _hashtable = new Hashtable();
        }

        public T GetValue<T>(string key)
            where T : class
        {
            return _hashtable.ContainsKey(key) ? (T)_hashtable[key] : null;
        }

        public void SetValue<T>(string key, T value)
            where T : class
        {
            if (_hashtable.ContainsKey(key))
                _hashtable[key] = value;
            else
                _hashtable.Add(key, value);
        }
    }
}
