using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Models
{
    public class EItem
    {
        public int Id{ get; set; }
        public string ItemName{ get; set; }
        public string ItemDescription{ get; set; }
        public decimal ItemRate{ get; set; }
        public string ItemRateDescription{ get; set; }
        public decimal ItemQuantity{ get; set; }
        public decimal ItemTotal{ get; set; }
        public bool isDeleted{ get; set; }
    }
}
