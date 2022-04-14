using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public class PastEventDTO
    {
        public int EventId { get; set; }


        public string EventTitle { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Date of Event")]
        public DateTime EventDate { get; set; }


        [Display(Name = "Location")]
        public string EventLocation { get; set; }

        [Display(Name = "Start Time(in 24 hr) ")]
        public string EventTime { get; set; }


        [Display(Name = "Type")]
        public string EventType { get; set; }


        [Display(Name = "Duration(in hr)")]
        public int Duration { get; set; }


        [Display(Name = "Description")]
        public string EventDescription { get; set; }


        [Display(Name = "Other Details")]
        public string EventDetails { get; set; }

        public string EventInvite { get; set; }
    }
}
