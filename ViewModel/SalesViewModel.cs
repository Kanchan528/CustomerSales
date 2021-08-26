using CustomerSales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.ViewModel
{
    public class SalesViewModel
    {
        public SalesMasterViewModel Master { get; set; }
        public List<SalesDetailViewModel> Details { get; set; }
    }
    public class SalesMasterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter sales number")]
        public string SalesNo { get; set; }
        [Required(ErrorMessage = "Please enter date")]
        public string SalesDate { get; set; }
        [Required(ErrorMessage = "Please enter discount amount")]
        public decimal Discount { get; set; }
        public decimal TotalSales { get; set; }
        public decimal NetAmount { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class SalesDetailViewModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter item rate")]
        public decimal Rate { get; set; }
        [Required(ErrorMessage = "Please enter item quantity")]
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public bool IsDeleted { get; set; }
        public int SalesId { get; set; }

    }
}
