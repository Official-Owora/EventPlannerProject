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
    internal sealed class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateNotification(Notification notification)
        {
            Create(notification);
        }

        public void DeleteNotification(Notification notification)
        {
            Delete(notification);
        }

        public async Task<IEnumerable<Notification>> FindAllNotificationsAsync(bool trackChanges)
        {
            return await FindAllAsync(trackChanges)
                .OrderBy(x=> x.Id)
                .ToListAsync();
        }

        public async Task<Notification> FindNotificationById(int id, bool trackChanges)
        {
            var notification = await FindByConditionAsync(x => x.Id == id, trackChanges).ToListAsync();

            return notification.FirstOrDefault();
        }

        public void UpdateNotification(Notification notification)
        {
            Update(notification);
        }
    }
}
