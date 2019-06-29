using GameEngine.GameObjects.Entities;
using GameEngine.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.DataAccess.Binary
{
    public class BinaryBaseEntityProvider : IBaseEntityProvider
    {
        private readonly ISurrogateSelector _surrogateSelector;
        private readonly StreamingContext _streamingContext;

        public BinaryBaseEntityProvider(ISurrogateSelector surrogateSelector, StreamingContext streamingContext)
        {
            _surrogateSelector = surrogateSelector;
            _streamingContext = streamingContext;
        }

        public BaseEntity Get(string entityName)
        {
            using (var fileInfo = new FileStream($"{entityName}.be", FileMode.Open))
            {
                var formatter = new BinaryFormatter
                {
                    Context = _streamingContext,
                    SurrogateSelector = _surrogateSelector
                };

                return (BaseEntity)formatter.Deserialize(fileInfo);
            }
        }

        public BaseEntity Save(BaseEntity entity)
        {
            using (var fileInfo = new FileStream($"{entity.Name}.be", FileMode.Create))
            {
                // ToDo сделать проверку возможности перезаписи

                var formatter = new BinaryFormatter()
                {
                    Context = _streamingContext,
                    SurrogateSelector = _surrogateSelector
                };

                formatter.Serialize(fileInfo, entity);
            }

            return entity;
        }
    }
}
