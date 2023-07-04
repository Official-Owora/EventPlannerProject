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
        Task<IEnumerable<Organizer>> FindAllOrganizerAsync(bool trackChanges);
        Task<Organizer> FindOrganizerByPhoneNumber(string phoneNumber, bool trackChanges);
        void CreateOrganizer(Organizer organizer);
        void UpdateOrganizer(Organizer organizer);
        void DeleteOrganizer(Organizer organizer);
    }
}
