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
        Task<IEnumerable<Events>> FindAllEventsAsync(bool trackChanges);
        Task<Events?> FindEventsByIdAsync(int Id, bool trackChanges);
        void CreateEvent(Events events);
        void DeleteEvent(Events events);
    }
}
