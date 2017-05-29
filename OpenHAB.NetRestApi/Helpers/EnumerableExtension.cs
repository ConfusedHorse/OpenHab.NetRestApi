using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OpenHAB.NetRestApi.Helpers
{
    public static class EnumerableExtension
    {
        [DebuggerStepThrough]
        public static void Each<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self) action(item);
        }

        [DebuggerStepThrough]
        public static void Each<T>(this ICollection self, Action<T> action)
        {
            foreach (var item in self) action((T) item);
        }

        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> self)
        {
            return self == null || self.IsEmpty();
        }

        [DebuggerStepThrough]
        public static bool IsEmpty<T>(this IEnumerable<T> self)
        {
            return !self.Any();
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }
    }
}