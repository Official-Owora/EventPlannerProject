using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.DTOs.ForDisplayDto
{
    public class NotificationForDisplayDto
    {

        public int RecipientId { get; set; }

        public string? Message { get; set; }

        public DateTime SentDate { get; set; }
    }
}
