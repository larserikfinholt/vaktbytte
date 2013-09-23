using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaktbytte.Models
{
    public class Change
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Ditt telefonnummer")]
        public string OwnerUserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Ditt navn")]
        public string OwnerName { get; set; }
        [Display(Name="Eventuelle kommentarer")]
        public string Comments { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Dato")]
        public DateTime Start { get; set; }
    }
}