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

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _assignmentService = new Lazy<IAssignmentService>(() => new AssignmentService(repository, logger, mapper));
            _eventsService = new Lazy<IEventsService>(() => new EventsService(repository, logger, mapper));
            _notificationService = new Lazy<INotificationService>(() => new NotificationService(repository, logger, mapper));
            _organizerService = new Lazy<IOrganizerService>(() => new OrganizerService(repository, logger, mapper));
            _participantService = new Lazy<IParticipantService>(() => new ParticipantService(repository, logger, mapper));
        }

        public IAssignmentService AssignmentService => _assignmentService.Value;

        public IEventsService EventsService => _eventsService.Value;

        public IParticipantService ParticipantService => _participantService.Value;

        public INotificationService NotificationService => _notificationService.Value;

        public IOrganizerService OrganizerService => _organizerService.Value;
    }
}
