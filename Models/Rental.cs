using System.ComponentModel.DataAnnotations;

namespace Renteal_Car.Models
{
    public class Rental
    {


        [Key]
        public int RentalId { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int CustmerId { get; set; }
        public Custamer Custamer { get; set; }

        public DataType StratRental { get; set; }

        public DataType EndRental { get; set; }
        public double Cost { get; set; }




    }
}
