using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAppPostgreSQL.Models
{
    public class SecurityContext : DbContext
    {
        public SecurityContext (DbContextOptions<SecurityContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetCoreAppPostgreSQL.Models.Security> Security { get; set; }
    }
}
