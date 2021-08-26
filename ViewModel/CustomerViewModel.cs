using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.ViewModel
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Enter your name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Enter your address")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage = "Enter your phone number")]
        public string ContactNumber { get; set; }
        public bool isDeleted { get; set; }
    }
}
