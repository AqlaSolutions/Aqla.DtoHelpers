using System;
using AqlaSerializer;
using KnightSaga;

namespace Aqla.DtoHelpers
{
    /// <summary>
    /// Writable struct by ref, don't use for nested
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [SerializableType(ModelId = AModelId.All, ImplicitFields = ImplicitFieldsMode.PublicFieldsAndProperties)]
    public class Ref<T> : IWrapper, IEquatable<T>, IEquatable<Ref<T>>, IEquatable<Getter<T>>
        where T : struct
    {
        /// <summary>
        /// 
        /// </summary>
        public T S;

        object IWrapper.Value => S;

        public Ref()
        {
        }

        public Ref(T s)
        {
            S = s;
        }

        public override int GetHashCode()
        {
            return S.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(obj, this)) return true;
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