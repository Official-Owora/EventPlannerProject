using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.DTOs.ForDisplayDto
{
    public class AssignmentForDisplayDto
    {
        public int Id { get; set; }
        public string? TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        public string? AssigneeFirstName { get; set; }
        public string? AssigneeLastName { get; set; }
        public string? AssigneeEmailAddress { get; set; }
        public string? AssigneePhoneNumber { get; set; }
        public string? TaskStatus { get; set; }
    }
}
