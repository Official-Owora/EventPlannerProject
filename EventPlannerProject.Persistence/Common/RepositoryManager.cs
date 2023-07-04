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
        
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _eventsRepository = new Lazy<IEventsRepository>(() => new EventsRepository(repositoryContext));
            _participantRepository = new Lazy<IParticipantRepository>(() => new ParticipantRepository(repositoryContext));
            _assignmentRepository = new Lazy<IAssignmentRepository>(() => new AssignmentRepository(repositoryContext));
        }

        public INotificationRepository NotificationRepository => throw new NotImplementedException();

        public IOrganizerRepository OrganizerRepository => throw new NotImplementedException();

        public IEventsRepository EventsRepository => _eventsRepository.Value;

        public IParticipantRepository ParticipantRepository => _participantRepository.Value;

        public IAssignmentRepository AssignmentRepository => _assignmentRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
