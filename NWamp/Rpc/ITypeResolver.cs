using System;
namespace NWamp.Rpc
{
    /// <summary>
    /// Type resolver used for converting objects parsed from JSON strings into specific type instances.
    /// </summary>
    public interface ITypeResolver
    {
        /// <summary>
        /// Converts provided deserialized JSON object into instance of <typeparamref name="TDestination"/> type.
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        TDestination Resolve<TDestination>(object jsonObject);

        /// <summary>
        /// Converts provided deserialized JSON object into instance of requested type.
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(object jsonObject, Type type);
    }
}
