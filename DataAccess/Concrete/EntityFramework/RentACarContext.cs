using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7BBVMRE\SQLEXPRESS;Database=RentACar;Trusted_Connection=true");
        }

        DbSet<Car> Cars { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Colour> Colours { get; set; }
    }
}
