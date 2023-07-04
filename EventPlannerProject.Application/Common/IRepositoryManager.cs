using EventPlannerProject.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.Common
{
    public interface IRepositoryManager
    {
        public INotificationRepository NotificationRepository { get; }
        public IOrganizerRepository OrganizerRepository { get; }
        public IEventsRepository EventsRepository { get; }
        public IParticipantRepository ParticipantRepository { get; }
        public IAssignmentRepository AssignmentRepository { get; }
        Task SaveAsync();
    }
}
