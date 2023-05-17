using MobilivaCase.Application.Constans.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.Result
{
    public class ApiResponse<T>
    {
        public Status Status { get; set; }
        public string ResultMessage { get; set; }
        public string ErrorCode { get; set; }
        public T? Data { get; set; }
    }
}
