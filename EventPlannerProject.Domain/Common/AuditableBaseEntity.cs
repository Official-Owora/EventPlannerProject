using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? StaffId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}