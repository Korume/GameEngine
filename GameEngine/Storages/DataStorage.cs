using GameEngine.Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Storages
{
    public class DataStorage : IDataStorage
    {
        private static Hashtable _hashtable;

        public DataStorage()
        {
            if (_hashtable == null)
            {
                _hashtable = new Hashtable(2);
            }
        }

        public T GetValue<T>(string key)
            where T : class
        {
            if(_hashtable.ContainsKey(key))
            {
                return (T)_hashtable[key];
            }
            return null;
        }

        public void SetValue<T>(string key, T value)
            where T : class
        {
            if (_hashtable.ContainsKey(key))
            {
                _hashtable[key] = value;
            }
            else
            {
                _hashtable.Add(key, value);
            }
        }
    }
}
