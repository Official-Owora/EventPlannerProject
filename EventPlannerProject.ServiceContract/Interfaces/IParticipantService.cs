using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceContract.Interfaces
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantForDisplayDto>> FindAllParticipantsAsync(bool trackChanges);
        Task<ParticipantForDisplayDto> FindParticipantsByIdAsync(int Id, bool trackChanges);
        Task<ParticipantForDisplayDto> CreateParticipantAsync(ParticipantForCreationDto participantForCreationDto);
        Task UpdateParticipantAsync(int Id, bool trackChanges);
        Task DeleteParticipantAsync(int Id, bool trackChanges);
    }
}
