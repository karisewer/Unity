using System;
using System.Collections.Generic;

namespace GitHub.Collections
{
    class LambdaComparer<T> : IEqualityComparer<T>, IComparer<T>
    {
        readonly Func<T, T, int> lambdaComparer;
        readonly Func<T, int> lambdaHash;

        public LambdaComparer(Func<T, T, int> lambdaComparer) :
            this(lambdaComparer, null)
        {
        }

        public LambdaComparer(Func<T, T, int> lambdaComparer, Func<T, int> lambdaHash)
        {
            this.lambdaComparer = lambdaComparer;
            this.lambdaHash = lambdaHash;
        }

        public int Compare(T x, T y)
        {
            return lambdaComparer(x, y);
        }

        public bool Equals(T x, T y)
        {
            return lambdaComparer(x, y) == 0;
        }

        public int GetHashCode(T obj)
        {
            return lambdaHash != null
                ? lambdaHash(obj)
                : obj?.GetHashCode() ?? 0;
        }
    }
}