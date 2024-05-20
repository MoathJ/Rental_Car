using Microsoft.EntityFrameworkCore;
using Renteal_Car.Models;

namespace Renteal_Car.Data
{
    public class RentalCarContext:DbContext
    {
        public RentalCarContext(DbContextOptions<RentalCarContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Custamer> Custamers { get; set; }
        public DbSet<Rental> Rentals { get; set; }



    }

}

