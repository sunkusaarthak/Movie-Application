﻿using System.ComponentModel.DataAnnotations;

namespace Movie_Application.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public required string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
