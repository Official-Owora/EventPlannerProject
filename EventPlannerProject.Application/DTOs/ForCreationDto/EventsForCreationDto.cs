using EventPlannerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.DTOs.ForCreationDto
{
    public class EventsForCreationDto
    {
        [Required(ErrorMessage = "Event description is required")]
        [MaxLength(100, ErrorMessage = "Maximum length for this description is 100 characters")]
        public string? EventDescription { get; set; }

        [Required(ErrorMessage = "Date of the event is required")]
        public DateTime? EventStartDate { get; set; }

        [Required(ErrorMessage = "Time of the event is required")]
        public string? EventStartTime { get; set; }

        [Required(ErrorMessage = "Venue of the event is required")]
        public string? EventVenue { get; set; }

        [Required(ErrorMessage = "Address of the event is required")]
        [MaxLength(50, ErrorMessage = "Maximum leength for this address is 50 characters")]
        public string? EventAddress { get; set; }

        [Required(ErrorMessage = "The state event will happen is required"), DataType(DataType.Text)]
        [MaxLength(20, ErrorMessage = "Maximum length for the state is 20 characters")]
        public string? EventLocationByState { get; set; }
    }
}
