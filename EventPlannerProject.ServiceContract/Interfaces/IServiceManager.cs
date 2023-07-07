using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceContract.Interfaces
{
    public interface IServiceManager
    {
        IAssignmentService AssignmentService { get; }
        IEventsService EventsService { get; }
        IParticipantService ParticipantService { get; }
        INotificationService NotificationService { get; }
        IOrganizerService OrganizerService { get; }
    }
}
