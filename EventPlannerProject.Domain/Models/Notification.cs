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
    public class Notification : AuditableBaseEntity
    {
        [ForeignKey(nameof(Events))]
        public int EventId { get; set; }
       
        [Required(ErrorMessage ="Recipient ID is required")]
        [MaxLength(5, ErrorMessage ="Maximum number for id is five digits")]
        public int RecipientId { get; set; }
        
        [Required(ErrorMessage = "Notification message is required")]
        public string? Message { get; set; }
       
        [Required(ErrorMessage = "Notification date is required")]
        public DateTime SentDate { get; set; }
    }
}
