using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPO.Models
{
    public class Message
    {
        [Key]
        public int MessageId {get;set;}

        [Display(Name="Full Name")]
        [Required]
        [MinLength(2)]
        public string FullName {get;set;}

        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Display(Name="Message")]
        [Required]
        public string VisitorMessage {get;set;}

    }
}