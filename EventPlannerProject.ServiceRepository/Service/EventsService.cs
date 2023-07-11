using AutoMapper;
using EventPlannerProject.Application.Common;
using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.Application.Exceptions;
using EventPlannerProject.Domain.Models;
using EventPlannerProject.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceRepository.Service
{
    internal sealed class EventsService : IEventsService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EventsService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EventsForDisplayDto> CreateEventsAsync(EventsForCreationDto eventsForCreationDto)
        {
            var eventsEntity = _mapper.Map<Events>(eventsForCreationDto);

            _repository.EventsRepository.CreateEvents(eventsEntity);
            await _repository.SaveAsync();

            var eventsToReturn = _mapper.Map<EventsForDisplayDto>(eventsEntity);
            return eventsToReturn;
        }

        public async Task DeleteEventsAsync(int Id, bool trackChanges)
        {
            var GetEvents = await _repository.EventsRepository.FindEventsByIdAsync(Id, trackChanges);
            if (GetEvents == null)
            {
                throw new NotFoundException($"Events with id: {Id} not found");
            }
            _repository.EventsRepository.DeleteEvents(GetEvents);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<EventsForDisplayDto>> FindAllEventsAsync(bool trackChanges)
        {
            var GetEventsEntities = await _repository.EventsRepository.FindAllEventsAsync(trackChanges);
            var eventsentities = _mapper.Map<IEnumerable<EventsForDisplayDto>>(GetEventsEntities);
            return eventsentities;
        }

        public async Task<EventsForDisplayDto> FindEventsByIdAsync(int Id, bool trackChanges)
        {
            var GetEventss = await _repository.EventsRepository.FindEventsByIdAsync(Id, trackChanges);
            if(GetEventss == null)
            {
                throw new NotFoundException($"Events with id: {Id} not found");
            }
            var EventsEntity = _mapper.Map<EventsForDisplayDto>(GetEventss);
            return EventsEntity;
        }

        public async Task UpdateEventsAsync(int Id, EventsForUpdateDto eventsForUpdateDto, bool trackChanges)
        {
            var GetEventsDetail = await _repository.EventsRepository.FindEventsByIdAsync(Id, trackChanges);
            if(GetEventsDetail == null)
            {
                throw new NotFoundException($"Events with id: {Id} not found");
            }
            _mapper.Map(eventsForUpdateDto, GetEventsDetail);
            await _repository.SaveAsync();
        }
    }
}
