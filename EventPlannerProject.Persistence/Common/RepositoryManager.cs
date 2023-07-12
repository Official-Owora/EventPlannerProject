using EventPlannerProject.Application.Common;
using EventPlannerProject.Application.Contracts;
using EventPlannerProject.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Persistence.Common
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IEventsRepository> _eventsRepository;
        private readonly Lazy<IParticipantRepository> _participantRepository;
        private readonly Lazy<IAssignmentRepository> _assignmentRepository;
        private readonly Lazy<IOrganizerRepository> _organizerRepository;
        private readonly Lazy<INotificationRepository> _notificationRepository;
        
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _eventsRepository = new Lazy<IEventsRepository>(() => new EventsRepository(repositoryContext));
            _participantRepository = new Lazy<IParticipantRepository>(() => new ParticipantRepository(repositoryContext));
            _assignmentRepository = new Lazy<IAssignmentRepository>(() => new AssignmentRepository(repositoryContext));
            _organizerRepository = new Lazy<IOrganizerRepository> (()=> new OrganizerRepository(repositoryContext));
            _notificationRepository = new Lazy<INotificationRepository> (()=> new NotificationRepository(repositoryContext));
        }

        public INotificationRepository NotificationRepository => _notificationRepository.Value;

        public IOrganizerRepository OrganizerRepository => _organizerRepository.Value;

        public IEventsRepository EventsRepository => _eventsRepository.Value;

        public IParticipantRepository ParticipantRepository => _participantRepository.Value;

        public IAssignmentRepository AssignmentRepository => _assignmentRepository.Value;

        public async Task SaveAsync()
        {
                await _repositoryContext.SaveChangesAsync();

            
            
        }
    }
}
