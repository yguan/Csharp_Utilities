using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Utilities.Mapper
{
    public static class ObjectMapper
    {
        public static Dictionary<string, Func<object, object>> MappingFunctions = new Dictionary<string, Func<object, object>>();
        public static void CreateMap<TSource, TDestination>(Func<TSource, TDestination> mappingFunction)
        {
            MappingFunctions[GetMappingKey(typeof(TSource), typeof(TDestination))] = o => mappingFunction((TSource)o);
        }

        public static string GetMappingKey(Type fromType, Type toType)
        {
            return string.Format("{0}->{1}", fromType, toType);
        }
    }

    public static class ObjectExtensions
    {
        public static TDestination MapTo<TDestination>(this object source)
        {
            return (TDestination)ObjectMapper.MappingFunctions[ObjectMapper.GetMappingKey(source.GetType(), typeof(TDestination))](source);
        }
    }
}
