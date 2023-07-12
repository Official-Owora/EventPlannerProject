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
    public class AssignmentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AssignmentController(IServiceManager service)
        {
            _serviceManager = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAssignment(AssignmentForCreationDto assignmentForCreationDto)
        {
            var createAssignment = await _serviceManager.AssignmentService.CreateAssignementAsync(assignmentForCreationDto);
            return Ok(createAssignment);
        }
        [HttpGet]
        public async Task<IActionResult> FindAllAssignment()
        {
            var assignments = await _serviceManager.AssignmentService.FindAllAssignmentsAsync(trackChanges: false);
            return Ok(assignments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindAssignmentById(int id)
        {
            var assignments = await _serviceManager.AssignmentService.FindAssignmentByIdAsync(id, trackChanges: false);
            return Ok(assignments);
        }
        [HttpDelete]
        public void DeleteAssingment(int Id)
        {
            _serviceManager.AssignmentService.DeleteAssignmentAsync(Id, trackChanges: false);
        }
        [HttpPut]
        public void UpdateAssignment(int Id)
        {
            _serviceManager.AssignmentService.UpdateAssignmentAsync(Id,  trackChanges: false);
        }
    }
}
