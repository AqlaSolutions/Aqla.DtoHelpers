using System;

namespace Aqla.DtoHelpers
{
    /// <summary>
    /// Writable struct by ref, don't use for nested
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Ref<T>
        where T : struct
    {
        /// <summary>
        /// 
        /// </summary>
        public T S;

        public Ref()
        {
        }

        public Ref(T s)
        {
            S = s;
        }
    }
}