using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.DTOs.ForDisplayDto
{
    public class ParticipantForDisplayDto
    {
        public int Id { get; set; }
        public string? ParticipantFirstName { get; set; }
        public string? ParticipantLastName { get; set; }
        public string? ParticipantEmailAddress { get; set; }
        public string? ParticipantPhoneNumber { get; set; }
        public string? RSVPStatus { get; set; } 
    }
}
