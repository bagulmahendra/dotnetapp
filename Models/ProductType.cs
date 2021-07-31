using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAppPostgreSQL.Models
{
    public enum ProductType
    {
        [Display(Name = "Euro Bond")]
        EuroBond,
        MTN,
        ECP,
        
        MBS,
        Loan,
        ABS
    }
}
