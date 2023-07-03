using EventPlannerProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Domain.Models
{
    public class Assignment : AuditableBaseEntity
    {
        [ForeignKey(nameof(Events))]
        public int EventsId { get; set; }

        [Required(ErrorMessage ="Name of the task is required")]
        [MaxLength(20, ErrorMessage ="Maximum length for the Task Title is 20 characters")]
        public string? TaskTitle { get; set; }

        [Required(ErrorMessage ="Task description is required")]
        [MaxLength(100, ErrorMessage ="Maximum length for this task description is 100 characters")]
        public string? TaskDescription { get; set; }

        [Required(ErrorMessage ="Assignee first name is required")]
        [MaxLength(30, ErrorMessage ="Maximum length for first name is 30 characters")]
        public string? AssigneeFirstName { get; set; }

        [Required(ErrorMessage = "Assignee last name is required")]
        [MaxLength(30, ErrorMessage = "Maximum length for last name is 30 characters")]
        public string? AssigneeLastName { get; set; }

        [Required(ErrorMessage ="Assignee email address is required")]
        public string? AssigneeEmailAddress { get; set; }

        [Required(ErrorMessage ="Phone Number of the Assignee is required"), DataType(DataType.PhoneNumber)]
        public string? AssigneePhoneNumber { get; set; }

        [Required(ErrorMessage ="Task status is required")]
        public string? TaskStatus { get; set; }
    }
}
