using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Business.Providers
{
    public interface IProvider<TEntity>
        where TEntity : class
    {
        TEntity Get();
        TEntity Save(TEntity entity);
    }
}