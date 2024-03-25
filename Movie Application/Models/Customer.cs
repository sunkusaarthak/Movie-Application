using System.ComponentModel.DataAnnotations;

namespace Movie_Application.Models
{
    public class Customer
    {
        //Id of the Cusrtomer
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public required string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
