using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqla.DtoHelpers
{
    public struct Getter<T>
        where T : struct
    {
        /// <summary>
        /// Requires explicit unwrap so that it's obvious that it's struct by .S
        /// </summary>
        public T S { get; }

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
            return S.Equals(obj);
        }
        
        public override string ToString()
        {
            return S.ToString();
        }
    }
}