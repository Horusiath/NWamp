using NWamp.Rpc;
using System;

namespace NWamp.Alchemy
{
    public class NewtonsoftTypeResolver : ITypeResolver
    {
        public TDestination Resolve<TDestination>(object jsonObject)
        {
            return (TDestination)Resolve(jsonObject, typeof (TDestination));
        }

        public object Resolve(object jsonObject, Type type)
        {
            if (type == typeof(string)) return jsonObject.ToString();

            var convert = Convert.ChangeType(jsonObject, type);
            if (convert != null)
                return convert;
            
            return jsonObject;
        }
    }
}
