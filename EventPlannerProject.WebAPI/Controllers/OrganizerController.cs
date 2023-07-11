using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrganizerController(IServiceManager service)
        {
            _serviceManager = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganizer(OrganizerForCreationDto organizer)
        {
            var Organizer = await _serviceManager.OrganizerService.CreateOrganizerAsync(organizer);
            return Ok(Organizer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrganizersAsync()
        {
            var organizers = await _serviceManager.OrganizerService.FindAllOrganizerAsync(trackChanges: true);
            return Ok(organizers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizerByIdAsync(int id)
        {
            var organizer = await _serviceManager.OrganizerService.FindOrganizerByIdAsync(id, trackchanges: false);
            return Ok(organizer);
        }

        [HttpDelete("{id}")]
        public void DeleteOrganizer(int id)
        {
            _serviceManager.OrganizerService.DeleteOrganizerAsync(id, trackChanges: false);

        }

        [HttpPut]
        public void UpdateOrganizer(int id)
        {
            _serviceManager.OrganizerService.UpdateOrganizerAsync(id, trackChanges: false);
        }
    }
}
