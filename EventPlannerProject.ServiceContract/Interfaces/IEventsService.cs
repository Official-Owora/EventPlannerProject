using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceContract.Interfaces
{
    public interface IEventsService
    {
        Task<IEnumerable<EventsForDisplayDto>> FindAllEventsAsync(bool trackChanges);
        Task<EventsForDisplayDto> FindEventsByIdAsync(int Id, bool trackChanges);
        Task<EventsForDisplayDto> CreateEventsAsync(EventsForCreationDto eventsForCreationDto);
        Task UpdateEventsAsync(int Id, EventsForUpdateDto eventsForUpdateDto, bool trackChanges);
        Task DeleteEventsAsync(int Id, bool trackChanges);
    }
}
