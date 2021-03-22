using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrowCmsAPI.Models
{
    public class TrowCmsContext : DbContext //extends dbcontext
    {
        public TrowCmsContext(DbContextOptions<TrowCmsContext> options) : base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }
    }
}
