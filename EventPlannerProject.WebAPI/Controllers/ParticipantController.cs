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
        private readonly IServiceManager _serviceManger;

        public ParticipantController(IServiceManager service)
        {
            _serviceManger = service;
        }
        [HttpPost]
        public void CreateParticipant(ParticipantForCreationDto participantForCreationDto)
        {
            _serviceManger.ParticipantService.CreateParticipantAsync(participantForCreationDto, trackChanges: false);
        }
        [HttpGet]
        public async Task<IActionResult>FindAllParticipant()
        {
            var participants = await _serviceManger.ParticipantService.FindAllParticipantsAsync(trackChanges: false);
            return Ok(participants);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult>FindParticipantById(int Id) 
        {
            var participants = await _serviceManger.ParticipantService.FindParticipantsByIdAsync(Id, trackChanges: false);
            return Ok(participants);
        }
        [HttpDelete]
        public void DeleteParticipant(int Id)
        {
            _serviceManger.ParticipantService.DeleteParticipantAsync(Id, trackChanges: false);
        }
        [HttpPut]
        public void UpdateParticipant(int Id, ParticipantForUpdateDto participantForUpdateDto)
        {
            _serviceManger.ParticipantService.UpdateParticipantAsync(Id, participantForUpdateDto, trackChanges: false);
        }
    }
}
