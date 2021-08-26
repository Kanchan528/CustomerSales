using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Models
{
    public class ECustomer
    {
        public int Id{ get; set; }
        public string CustomerName{ get; set; }
        public string CustomerAddress{ get; set; }
        public string ContactNumber{ get; set; }
        public bool isDeleted{ get; set; }
    }
}
