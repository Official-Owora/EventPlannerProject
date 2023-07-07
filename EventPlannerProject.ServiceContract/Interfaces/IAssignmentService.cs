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
        Task<AssignmentForDisplayDto> FindAssignmentByAssigneePhoneNumberAsync(string AssigneePhoneNumber, bool trackChanges);
        Task<AssignmentForCreationDto> CreateAssignementAsync(AssignmentForCreationDto assignmentForCreationDto);
        Task UpdateAssignmentAsync(int Id, AssignmentForUpdateDto assignmentForUpdateDto, bool trackChanges);
        Task DeleteAssignmentAsync(int Id, bool trackChanges);
    }
}
