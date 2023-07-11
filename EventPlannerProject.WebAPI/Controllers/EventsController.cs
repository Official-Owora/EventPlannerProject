using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IServiceManager _serviceManger;
        public EventsController(IServiceManager service)
        {
            _serviceManger = service;
        }
        [HttpPost]
        public void CreateEvents(EventsForCreationDto eventsForCreationDto)
        {
            _serviceManger.EventsService.CreateEventsAsync(eventsForCreationDto);
        }
        [HttpGet]
        public async Task<IActionResult> FindAllEvents()
        {
            var eventss = await _serviceManger.EventsService.FindAllEventsAsync(trackChanges: false);
            return Ok(eventss);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> FindEventsById(int Id)
        {
            var eventss = await _serviceManger.EventsService.FindEventsByIdAsync(Id, trackChanges: false);
            return Ok(eventss);
        }
        [HttpDelete]
        public void DeleteEvents(int Id)
        {
            _serviceManger.EventsService.DeleteEventsAsync(Id, trackChanges: false);
        }
        [HttpPut]
        public void UpdateEvents(int Id, EventsForUpdateDto eventsForUpdateDto)
        {
            _serviceManger.EventsService.UpdateEventsAsync(Id, eventsForUpdateDto, trackChanges: false);
        }
    }
}
