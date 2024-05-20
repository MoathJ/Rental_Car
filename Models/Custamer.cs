using System.ComponentModel.DataAnnotations;

namespace Renteal_Car.Models
{
    public class Custamer
    {
        [Key]
        public int CustmerId { get; set; }
        [Required]
        public string CustmerName { get; set; }

        public string ContactInfo { get; set; }


    }
}
