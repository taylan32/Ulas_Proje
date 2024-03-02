using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class BusinessException : Exception
    {
        public int StatusCode { get; set; }
        public BusinessException(string message, int? statusCode) : base(message)
        {
            StatusCode = statusCode == 0 ? 400 : Convert.ToInt32(statusCode);
        }
    }
}
