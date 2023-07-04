using EventPlannerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.Contracts
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> FindAllNotificationsAsync(bool trackChanges);
        Task<Notification> FindNotificationById(int Id, bool trackChanges);
        void CreateNotification(Notification notification);
        void DeleteNotification(Notification notification);
        void UpdateNotification(Notification notification);
    }
}
