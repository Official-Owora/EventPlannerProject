using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public EventsController(IServiceManager service)
        {
            _serviceManager = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvents(EventsForCreationDto eventsForCreationDto)
        {
            var createEvents = await _serviceManager.EventsService.CreateEventsAsync(eventsForCreationDto);
            return Ok(createEvents);
        }
        [HttpGet]
        public async Task<IActionResult> FindAllEvents()
        {
            var eventss = await _serviceManager.EventsService.FindAllEventsAsync(trackChanges: false);
            return Ok(eventss);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> FindEventsById(int Id)
        {
            var eventss = await _serviceManager.EventsService.FindEventsByIdAsync(Id, trackChanges: false);
            return Ok(eventss);
        }
        [HttpDelete]
        public void DeleteEvents(int Id)
        {
            _serviceManager.EventsService.DeleteEventsAsync(Id, trackChanges: false);
        }
        [HttpPut]
        public void UpdateEvents(int Id, EventsForUpdateDto eventsForUpdateDto)
        {
            _serviceManager.EventsService.UpdateEventsAsync(Id, eventsForUpdateDto, trackChanges: false);
        }
    }
}
