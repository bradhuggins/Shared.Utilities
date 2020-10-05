#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#endregion


namespace Shared.Utilities
{
    public static class TransformationHelper
    {
        /// <summary>
        /// Copies the properties.
        /// </summary>
        /// <typeparam name="J"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public static K CopyProperties<J, K>(J source, K destination)
        {
            var s = source.GetType();
            var sourceProperties = s.GetProperties();

            var d = destination.GetType();
            var destinationProperties = d.GetProperties();

            foreach (PropertyInfo sp in sourceProperties)
            {
                var dp =
                    destinationProperties.SingleOrDefault(
                    x => x.Name == sp.Name &&
                        x.PropertyType == sp.PropertyType);

                if (dp != null && dp.CanWrite)
                    dp.SetValue(destination, sp.GetValue(source, null), null);
            }

            return destination;
        }

        /// <summary>
        /// Copies the collection.
        /// </summary>
        /// <typeparam name="J"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public static List<K> CopyCollection<J, K>(List<J> source, List<K> destination)
        {
            foreach (var item in source)
            {
                destination.Add(CopyProperties<J, K>(item, (K)Activator.CreateInstance(typeof(K))));
            }

            return destination;
        }


    }
}
