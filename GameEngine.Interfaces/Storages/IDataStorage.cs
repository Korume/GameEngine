using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.Storages
{
    public interface IDataStorage
    {
        T GetValue<T>(string key) where T : class;
        void SetValue<T>(string key, T value) where T : class;
    }
}
