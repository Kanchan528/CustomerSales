using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter item name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Enter item description")]
        public string ItemDescription { get; set; }
        [Required(ErrorMessage = "Enter item rate")]
        public decimal ItemRate { get; set; }
        [Required(ErrorMessage = "Enter item rate description")]
        public string ItemRateDescription { get; set; }
        [Required(ErrorMessage = "Enter item quantity")]
        public decimal ItemQuantity { get; set; }
        [Required(ErrorMessage = "Enter item total")]
        public decimal ItemTotal { get; set; }
        public bool isDeleted { get; set; }
    }
}
