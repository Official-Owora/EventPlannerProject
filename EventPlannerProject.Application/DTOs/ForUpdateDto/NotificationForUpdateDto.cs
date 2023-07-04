using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.DTOs.ForUpdateDto
{
    public class NotificationForUpdateDto
    {
        [Required(ErrorMessage = "Recipient ID is required")]
        [MaxLength(5, ErrorMessage = "Maximum number for id is five digits")]
        public int RecipientId { get; set; }

        [Required(ErrorMessage = "Notification message is required")]
        public string? Message { get; set; }

        [Required(ErrorMessage = "Notification date is required")]
        public DateTime SentDate { get; set; }
    }
}
