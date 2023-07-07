using AutoMapper;
using EventPlannerProject.Application.Common;
using EventPlannerProject.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceRepository.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAssignmentService> _assignmentService;
        private readonly Lazy<IEventsService> _eventsService;
        private readonly Lazy<INotificationService> _notificationService;
        private readonly Lazy<IOrganizerService> _organizerService;
        private readonly Lazy<IParticipantService> _participantService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _notificationService = new Lazy<INotificationService>(() => new NotificationService(repositoryManager, loggerManager, mapper));
            _organizerService = new Lazy<IOrganizerService>(() => new OrganizerService(repositoryManager, loggerManager, mapper));
        }

        public IAssignmentService AssignmentService => throw new NotImplementedException();

        public IEventsService EventsService => throw new NotImplementedException();

        public IParticipantService ParticipantService => throw new NotImplementedException();

        public INotificationService NotificationService => _notificationService.Value;

        public IOrganizerService OrganizerService => _organizerService.Value;
    }
}
