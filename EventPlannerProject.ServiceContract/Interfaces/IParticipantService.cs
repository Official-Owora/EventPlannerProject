using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceContract.Interfaces
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantForDisplayDto>> FindAllParticipantAsync(bool trackChanges);
        Task<ParticipantForDisplayDto> FindParticipantsByPhoneNumberAsync(string ParticipantPhoneNumber, bool trackChanges);
        Task<ParticipantForCreationDto> CreateParticipantAsync(ParticipantForDisplayDto participantForDisplayDto, bool trackChanges);
        Task UpdateParticipantAsync(int Id, ParticipantForDisplayDto participantForDisplayDto, bool trackChanges);
        Task DeleteParticipantAsync(int Id, bool trackChanges);
    }
}
