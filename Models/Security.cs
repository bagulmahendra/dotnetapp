using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAppPostgreSQL.Models
{
    public class Security
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Security Id")]
        public string SecurityId { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        public ProductType ProductType { get; set; }

        [Required]
        [Display(Name = "Deal ID")]
        public string DealID { get; set; }

        [Required] 
        [Display(Name = "Issuer")]
        public string Issuer { get; set; }

        [Required] 
        [Display(Name = "Currency")]
        public string Currency { get; set; }
    }
}
