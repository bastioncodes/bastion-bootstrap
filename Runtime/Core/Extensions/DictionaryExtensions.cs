using System;
using System.Collections.Generic;

namespace Bastion.Core.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> destination, IDictionary<TKey, TValue> source)
        {
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (source == null) throw new ArgumentNullException(nameof(source));
        
            foreach (var pair in source)
            {
                destination[pair.Key] = pair.Value;
            }
        }
    }
}