using EventPlannerProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Persistence.Common
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) 
        { 
        }
        //this code overrides two the primary-foreign key tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .HasKey(x => new { x.EventId, x.OrganizerId });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Events> Events { get; set; }
    }
}
