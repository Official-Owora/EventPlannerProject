using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceContract.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationForDisplayDto>> FindAllNotificationAsync(bool trackChanges);
        Task<NotificationForDisplayDto> FindNotificationByRecipientId(int  recipientId, bool trackChanges);
        Task<NotificationForCreationDto> CreateNotificationAsync(NotificationForCreationDto notificationForCreationDto);
        Task UpdateNotificationAsync(int id,  NotificationForDisplayDto notificationForDisplayDto, bool trackChanges);
        Task DeleteNotificationAsync(int id);
    }
}
