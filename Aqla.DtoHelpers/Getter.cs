using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aqla.DtoHelpers
{
    public struct Getter<T> : IWrapper, IEquatable<T>, IEquatable<Ref<T>>, IEquatable<Getter<T>>
        where T : struct
    {
        /// <summary>
        /// Requires explicit unwrap so that it's obvious that it's struct by .S
        /// </summary>
        public T S { get; }

        object IWrapper.Value => S;

        public Getter(T s)
        {
            S = s;
        }
        
        public static implicit operator Getter<T>(T v)
        {
            return new Getter<T>(v);
        }

        public override int GetHashCode()
        {
            return S.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var r = obj as IWrapper;
            if (r != null) return S.Equals(r.Value);
            return S.Equals(obj);
        }
        public bool Equals(T other)
        {
            return S.Equals(other);
        }

        public bool Equals(Ref<T> other)
        {
            return Equals((object)other);
        }

        public bool Equals(Getter<T> other)
        {
            return S.Equals(other.S);
        }

        public override string ToString()
        {
            return S.ToString();
        }
    }
}