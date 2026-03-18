using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myApi.Model;

namespace myApi.Data
{
    public class myApiContext : DbContext
    {
        public myApiContext (DbContextOptions<myApiContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
    }
}
