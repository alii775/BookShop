using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Data
{
    public class BookDbContext : IdentityDbContext<User,Role, int>
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autor { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItems> BasketItems { get; set; }


       
    }
   
}
