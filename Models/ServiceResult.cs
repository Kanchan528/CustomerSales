using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Models
{
    public class ServiceResult<T>
    {
        public T Data { get; set; }
        public string Message{ get; set; }
        public ResultStatus ResultStatus{ get; set; }
    }

    public enum ResultStatus
    {
        Ok,
        Error
    }
}
