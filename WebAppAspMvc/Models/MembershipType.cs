using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAspMvc.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }


        [StringLength(50)]
        public string Name { get; set; }

        public float Price { get; set; }

        [Range(0.00, 0.20, ErrorMessage = "Discount Rate must be between 0.00 and 0.20")]

        public float DiscountRate { get; set; }

    }
}
