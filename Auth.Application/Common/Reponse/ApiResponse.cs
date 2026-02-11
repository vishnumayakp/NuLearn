using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Common.Reponse
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object ErrorMessage { get; set; }
    }
}
