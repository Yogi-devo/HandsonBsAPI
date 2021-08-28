using HandsonBsAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsonBsAPI.Data
{
    public class BsContext : IdentityDbContext<ApplicationUser>
    {
        public BsContext(DbContextOptions<BsContext> options)
            : base(options)
        { }
        public DbSet<Books> Books { get; set; }

        internal T Map<T>(Books book)
        {
            throw new NotImplementedException();
        }
    }
}
