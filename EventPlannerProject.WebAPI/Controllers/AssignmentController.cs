using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IServiceManager _serviceManger;

        public AssignmentController(IServiceManager service)
        {
            _serviceManger = service;
        }
        [HttpPost]
        public void CreateAssignment(AssignmentForCreationDto assignmentForCreationDto)
        {
            _serviceManger.AssignmentService.CreateAssignementAsync(assignmentForCreationDto);
        }
        [HttpGet]
        public async Task<IActionResult> FindAllAssignment()
        {
            var assignments = await _serviceManger.AssignmentService.FindAllAssignmentsAsync(trackChanges: false);
            return Ok(assignments);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> FindAssignmentById(int Id)
        {
            var assignments = await _serviceManger.AssignmentService.FindAssignmentByIdAsync(Id, trackChanges: false);
            return Ok(assignments);
        }
        [HttpDelete]
        public void DeleteAssingment(int Id)
        {
            _serviceManger.AssignmentService.DeleteAssignmentAsync(Id, trackChanges: false);
        }
        [HttpPut]
        public void UpdateAssignment(int Id, AssignmentForUpdateDto assignemntForUpdateDto)
        {
            _serviceManger.AssignmentService.UpdateAssignmentAsync(Id, assignemntForUpdateDto, trackChanges: false);
        }
    }
}
