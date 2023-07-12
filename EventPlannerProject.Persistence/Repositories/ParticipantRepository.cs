using EventPlannerProject.Application.Contracts;
using EventPlannerProject.Application.Exceptions;
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
    internal sealed class ParticipantRepository : RepositoryBase<Participant>, IParticipantRepository
    {
        public ParticipantRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateParticipant(Participant participant)
        {
            Create(participant);
        }

        public void DeleteParticipant(Participant participant)
        {
            Delete(participant);
        }

        public async Task<IEnumerable<Participant>> FindAllParticipantsAsync(bool trackChanges)
        {
            return await FindAllAsync(trackChanges)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Participant> FindParticipantsByIdAsync(int Id, bool trackChanges)
        {
            var participant = await FindByConditionAsync(x => x.Id == Id, trackChanges).ToListAsync();
            return participant.FirstOrDefault();

        }

        public void UpdateParticipant(Participant participant)
        {
           Update(participant);
        }
    }
}
