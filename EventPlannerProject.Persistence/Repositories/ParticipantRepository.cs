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
    internal sealed class ParticipantRepository : RepositoryBase<Participant>, IParticipantRepository
    {
        public ParticipantRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateParticipant(Participant participant)
        {
            CreateParticipant(participant);
        }

        public void DeleteParticipant(Participant participant)
        {
            DeleteParticipant(participant);
        }

        public async Task<IEnumerable<Participant>> FindAllParticipantsAsync(bool trackChanges)
        {
            return await FindAllAsync(trackChanges)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Participant> FindByParticipantPhoneNumber(string ParticipantPhoneNumber, bool trackChanges)
        {
            var participant = await FindByConditionAsync(x => x.ParticipantPhoneNumber == ParticipantPhoneNumber, trackChanges).ToListAsync();
            return participant.FirstOrDefault();
        }

        public void UpdateParticipant(Participant participant)
        {
           UpdateParticipant(participant);
        }
    }
}
