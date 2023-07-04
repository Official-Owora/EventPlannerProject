using EventPlannerProject.Application.Contracts;
using EventPlannerProject.Domain.Models;
using EventPlannerProject.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Persistence.Repositories
{
    internal sealed class EventsRepository : RepositoryBase<Events>, IEventsRepository
    {
        public EventsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEvents(Events events)
        {
            CreateEvents(events);
        }

        public void DeleteEvents(Events events)
        {
            Delete(events);
        }

        public async Task<IEnumerable<Events>> FindAllEventsAsync(bool trackChanges)
        {
            return await FindAllAsync(trackChanges)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Events?> FindEventsByIdAsync(int Id, bool trackChanges)
        {
            var events = await FindByConditionAsync(x => x.Id == Id, trackChanges).ToListAsync();
            return events.FirstOrDefault();
        }

        public void UpdateEvents(Events events)
        {
            UpdateEvents(events);
        }
    }
}
