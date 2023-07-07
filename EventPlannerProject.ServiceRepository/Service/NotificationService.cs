using AutoMapper;
using EventPlannerProject.Application.Common;
using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.Domain.Models;
using EventPlannerProject.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceRepository.Service
{
    internal sealed class NotificationService : INotificationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public NotificationService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper  mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public async Task<NotificationForDisplayDto> CreateNotificationAsync(NotificationForCreationDto notificationForCreationDto)
        {
            var NotificationEntity = _mapper.Map<Notification>(notificationForCreationDto);
            _repositoryManager.NotificationRepository.CreateNotification(NotificationEntity);
            await _repositoryManager.SaveAsync();

            var NotificationToReturn = _mapper.Map<NotificationForDisplayDto>(NotificationEntity);

            return NotificationToReturn;


        }

        public async Task DeleteNotificationAsync(int id, bool trackChanges)
        {
            var NotificationToDelete = await _repositoryManager.NotificationRepository.FindNotificationById(id, trackChanges);
            if (NotificationToDelete != null)
            {
                _repositoryManager.NotificationRepository.DeleteNotification(NotificationToDelete);
            }
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<NotificationForDisplayDto>> FindAllNotificationAsync(bool trackChanges)
        {
            var Notifications = await  _repositoryManager.NotificationRepository.FindAllNotificationsAsync(trackChanges);
           var NotificationToReturn = _mapper.Map<IEnumerable<NotificationForDisplayDto>>(Notifications);
            return NotificationToReturn;
        }

        public async Task<NotificationForDisplayDto> FindNotificationByRecipientId(int recipientId, bool trackChanges)
        {
            var Notification = await _repositoryManager.NotificationRepository.FindNotificationById(recipientId, trackChanges);
            if (Notification != null)
            {
                //throw an exception
            }
            var NotificationToReturn = _mapper.Map<NotificationForDisplayDto>(Notification); 
            return NotificationToReturn;

        }

        public async Task UpdateNotificationAsync(int id, bool trackChanges)
        {
            var Notification = await _repositoryManager.NotificationRepository.FindNotificationById(id, trackChanges);
            _mapper.Map<Notification>(Notification);
            await _repositoryManager.SaveAsync();
        }
    }
}
