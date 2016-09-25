﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace TeamRepository.MultipleQuery.Sql
{
    public static class DapperMapperHelper
    {
        /// <summary>
        /// Extension Method on Grid Reader
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="reader"></param>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <param name="firstKey"></param>
        /// <param name="secondKey"></param>
        /// <param name="addChildren"></param>
        /// <returns></returns>
        public static IEnumerable<TFirst> MapChild<TFirst, TSecond, TKey>(
             this SqlMapper.GridReader reader,
             List<TFirst> parent,
             List<TSecond> child,
             Func<TFirst, TKey> firstKey,
             Func<TSecond, TKey> secondKey,
             Action<TFirst, IEnumerable<TSecond>> addChildren)
        {
            var childMap = child.GroupBy(secondKey).ToDictionary(g => g.Key, g => g.AsEnumerable());
            foreach (var item in parent)
            {
                IEnumerable<TSecond> children;
                if (childMap.TryGetValue(firstKey(item), out children))
                {
                    addChildren(item, children);
                }

                if (children == null)
                {
                    addChildren(item, new List<TSecond>());
                }
            }
            return parent;
        }
    }
}
