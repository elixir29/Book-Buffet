using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public class EventDTO
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z\\s]{3,20}$", ErrorMessage = "Please enter string only.")]
        public string EventTitle { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [EventDateValidation]
        [Display(Name = "Date of Event")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string EventLocation { get; set; }

        [Display(Name = "Start Time(in 24 hr) ")]
        [Required]
        public string EventTime { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string EventType { get; set; }

        [Required]
        [Display(Name = "Duration(in hr)")]
        public int EventDuration { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Description")]
        public string EventDescription { get; set; }


        [Display(Name = "Other Details")]
        [MaxLength(500)]
        public string EventDetails { get; set; }

        public string EventInvite { get; set; }

        public int UserId { get; set; }
    }
}
