using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.Domain.Models;
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
        Task<OrganizerForDisplayDto> FindOrganizerByIdAsync(int id, bool trackchanges);
        Task<OrganizerForDisplayDto> CreateOrganizerAsync(OrganizerForCreationDto organizerDto);
        Task UpdateOrganizerAsync(int id, bool trackChanges);
        Task DeleteOrganizerAsync(int id, OrganizerForUpdateDto organizerDto, bool trackChanges);

    }
}
