using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceContract.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentForDisplayDto>> FindAllAssignmentsAsync(bool trackChanges);
        Task<AssignmentForDisplayDto> FindAssignmentByIdAsync(int id, bool trackChanges);
        Task<AssignmentForDisplayDto> CreateAssignementAsync(AssignmentForCreationDto assignmentForCreationDto);
        Task UpdateAssignmentAsync(int Id, bool trackChanges);
        Task DeleteAssignmentAsync(int Id, bool trackChanges);
    }
}
