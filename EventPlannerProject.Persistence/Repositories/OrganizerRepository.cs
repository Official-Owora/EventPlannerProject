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
    internal sealed class OrganizerRepository : RepositoryBase<Organizer>, IOrganizerRepository
    {
        public OrganizerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateOrganizer(Organizer organizer)
        {
            Create(organizer);
        }

        public void DeleteOrganizer(Organizer organizer)
        {
            Delete(organizer);
        }

        public async Task<IEnumerable<Organizer>> FindAllOrganizersAsync(bool trackChanges)
        {
            return await FindAllAsync(trackChanges)
                .OrderBy(x=> x.Id)
                .ToListAsync();
        }

        public async Task<Organizer> FindOrganizerById(int Id, bool trackChanges)
        {
            var organizer = await FindByConditionAsync(x=> x.Id == Id, trackChanges)
                .ToListAsync();

            return organizer.FirstOrDefault();
        }

        public void UpdateOrganizer(Organizer organizer)
        {
            Update(organizer);
        }
    }
}
