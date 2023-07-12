using EventPlannerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.Contracts
{
    public interface IOrganizerRepository
    {
        Task<IEnumerable<Organizer>> FindAllOrganizersAsync(bool trackChanges);
        Task<Organizer> FindOrganizerById(int id, bool trackChanges);
        void CreateOrganizer(Organizer organizer);
        void UpdateOrganizer(Organizer organizer);
        void DeleteOrganizer(Organizer organizer);
    }
}
