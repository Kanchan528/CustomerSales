using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Models
{
    public class ESales
    {
        public int Id{ get; set; }
        public string SalesNo{ get; set; }
        public DateTime SalesDate{ get; set; }
        public decimal Discount{ get; set; }
        public decimal TotalSales{ get; set; }
        public decimal NetAmount{ get; set; }
        public bool IsDeleted{ get; set; }
    }

    public class ESalesDetail
    {
        public int Id{ get; set; }
        public int ItemId{ get; set; }
        public int CustomerId{ get; set; }
        public decimal Rate{ get; set; }
        public decimal Quantity{ get; set; }
        public decimal Total{ get; set; }
        public bool IsDeleted{ get; set; }
        public int SalesId{ get; set; }
        public virtual ESales Sales{ get; set; }
    }
}
