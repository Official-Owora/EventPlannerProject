using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ParticipantController(IServiceManager service)
        {
            _serviceManager = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateParticipant(ParticipantForCreationDto participantForCreationDto)
        {
            var createParticipant = await _serviceManager.ParticipantService.CreateParticipantAsync(participantForCreationDto);
            return Ok(createParticipant);
        }
        [HttpGet]
        public async Task<IActionResult>FindAllParticipant()
        {
            var participants = await _serviceManager.ParticipantService.FindAllParticipantsAsync(trackChanges: false);
            return Ok(participants);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult>FindParticipantById(int Id) 
        {
            var participants = await _serviceManager.ParticipantService.FindParticipantsByIdAsync(Id, trackChanges: false);
            return Ok(participants);
        }
        [HttpDelete]
        public void DeleteParticipant(int Id)
        {
            _serviceManager.ParticipantService.DeleteParticipantAsync(Id, trackChanges: false);
        }
        [HttpPut]
        public void UpdateParticipant(int Id)
        {
            _serviceManager.ParticipantService.UpdateParticipantAsync(Id,  trackChanges: false);
        }
    }
}
