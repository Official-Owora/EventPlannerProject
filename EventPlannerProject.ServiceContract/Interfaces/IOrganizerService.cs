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
    public interface IOrganizerService
    {
        Task<IEnumerable<OrganizerForDisplayDto>> FindAllOrganizerAsync(bool trackChanges);
        Task<OrganizerForDisplayDto> FindOrganizerByPhoneNumberAsync(string phoneNumber);
        Task<OrganizerForCreationDto> CreateOrganizerAsync(OrganizerForCreationDto organizerForCreationDto);
        Task UpdateOrganizerAsync(int id, OrganizerForUpdateDto organizerForUpdateDto, bool trackChanges);
        Task DeleteOrganizerAsync(int id);

    }
}
