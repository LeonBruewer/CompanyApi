using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApi.Helper
{
    [Serializable]

    public class RepositoryException<T> : Exception
    {
        public T Type { get; set; }

        public RepositoryException(T type)
        {
            Type = type;
        }
        public RepositoryException(string message, T type) : base(message)
        {
            Type = type;
        }
        public RepositoryException(string message, Exception inner) : base(message, inner) { }
        protected RepositoryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}