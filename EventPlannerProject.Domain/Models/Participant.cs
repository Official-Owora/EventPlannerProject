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
    public class Participant : AuditableBaseEntity
    {
        [ForeignKey(nameof(Events))]
        public int EventId { get; set; }

        /*[ForeignKey(nameof(Client))]
        public int ClientId { get; set; }*/

        [Required(ErrorMessage = "RSVP Status is required")]
        public string? RSVPStatus { get; set; }
    }
}
