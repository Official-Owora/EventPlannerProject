using EventPlannerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.Contracts
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> FindAllParticipantsAsync(bool trackChanges);
        Task<Participant>FindByParticipantPhoneNumber(string ParticipantPhoneNumber, bool trackChanges);
        void CreateParticipant(Participant participant);
        void DeleteParticipant(Participant participant);
        void UpdateParticipant(Participant participant);
    }
}
