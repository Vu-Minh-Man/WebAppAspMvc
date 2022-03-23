using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAspMvc.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Subscribed to Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }

        //[ForeignKey("MembershipType")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

    }
}
