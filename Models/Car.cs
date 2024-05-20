using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Renteal_Car.Models
{
    public class Car
    {
        
        [Key]
        public int CarId { get; set; }

        public string MakeContry { get; set; }

        public int Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Color { get; set; }

        public int Mileage { get; set; }

        [Required]
        public string RentalState {  get; set; }

    }
}
