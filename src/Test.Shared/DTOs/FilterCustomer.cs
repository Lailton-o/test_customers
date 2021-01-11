using System;
using System.ComponentModel.DataAnnotations;

namespace Test.Shared.DTOs
{
    public class FilterCustomer
    {
        [StringLength(50, MinimumLength = 6)]
        public string Name { get; set; }
        public int? Gender { get; set; }
        public int? City { get; set; }
        public int? Region { get; set; }
        [Display(Name= "Last_LastPurchase")]
        public DateTime? LastPurchaseBegins { get; set; }
        [Display(Name = "Last_LastPurchase_Until")]
        public DateTime? LastPurchaseEnds { get; set; }
        public int? Classification { get; set; }
        public int? Seller { get; set; }
    }
}
