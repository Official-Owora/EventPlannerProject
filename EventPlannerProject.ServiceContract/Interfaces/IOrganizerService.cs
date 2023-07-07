using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
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
        Task<OrganizerForDisplayDto> CreateOrganizerAsync(OrganizerForUpdateDto organizer);
        Task UpdateNotificationAsync(int id, OrganizerForDisplayDto organizer, bool trackChanges);
        Task DeleteNotificationAsync(int id);

    }
}
