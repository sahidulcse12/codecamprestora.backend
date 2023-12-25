using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Exceptions
{
    public class GenericException<T> : Exception where T : Exception
    {
        public T CustomException { get; set; }

        public GenericException(T customException, string message) : base(message)
        {
            CustomException = customException;
        }

        public GenericException(T customException, string message, Exception innerException) : base(message, innerException)
        {
            CustomException = customException;
        }
    }
}
