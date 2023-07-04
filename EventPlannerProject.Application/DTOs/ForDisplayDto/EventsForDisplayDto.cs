using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.DTOs.ForDisplayDto
{
    public class EventsForDisplayDto
    {
        public string? EventDescription { get; set; }
        public DateTime? EventStartDate { get; set; }
        public string? EventStartTime { get; set;}
        public string? EventVenue { get; set; }
        public string? EventAddress { get; set;}
        public string? EventLocationByState { get; set; }
    }
}
