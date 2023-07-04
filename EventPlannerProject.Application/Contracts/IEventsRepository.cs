using EventPlannerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.Contracts
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Events>> GetAllEventsAsync(bool trackChanges);
        Task<Events?> GetEventsByIdAsync(int Id, bool trackChanges);
        void CreateEvents(Events events);
        void DeleteEvents(Events events);
        void UpdateEvents(Events events);
    }
}
