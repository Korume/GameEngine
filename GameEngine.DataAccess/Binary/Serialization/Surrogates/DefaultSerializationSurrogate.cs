using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.DataAccess.Binary.Serialization.Surrogates
{
    public class DefaultSerializationSurrogate<T> : ISerializationSurrogate
    {
        private IEnumerable<PropertyInfo> _propertyInfos;
        private IEnumerable<FieldInfo> _fieldInfos;

        private void InitInfoFields()
        {
            _propertyInfos = typeof(T).GetProperties()
                .Where(p => (p.SetMethod?.Attributes.HasFlag(MethodAttributes.Public) ?? false)
                && (p.GetMethod?.Attributes.HasFlag(MethodAttributes.Public) ?? false));

            _fieldInfos = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
        }

        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            InitInfoFields();

            foreach (var propertyInfo in _propertyInfos)
            {
                info.AddValue(propertyInfo.Name, propertyInfo.GetValue(obj), propertyInfo.PropertyType);
            }

            foreach (var fieldInfo in _fieldInfos)
            {
                info.AddValue(fieldInfo.Name, fieldInfo.GetValue(obj), fieldInfo.FieldType);
            }
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            InitInfoFields();

            obj = Activator.CreateInstance(typeof(T));

            foreach (var propertyInfo in _propertyInfos)
            {
                var propertyValue = info.GetValue(propertyInfo.Name, propertyInfo.PropertyType);
                propertyInfo.SetValue(obj, propertyValue);
            }

            foreach (var fieldInfo in _fieldInfos)
            {
                var fieldValue = info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
                fieldInfo.SetValue(obj, fieldValue);
            }
            return obj;
        }
    }
}
