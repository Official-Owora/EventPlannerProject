﻿using EventPlannerProject.Application.DTOs.ForDisplayDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceContract.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentForDisplayDto>> FindAssignmentsAsync(bool trachChanges);
        Task<AssignmentForDisplayDto>FinsAssignmentByAssigneePhoneNumberAsync(string phoneNumber, bool trackChanges);
        Task<AssignmentForDisplayDto> CreateAssignementAsync(AssignmentForDisplayDto assignmentForDisplayDto);
        Task UpdateAssignmentAsync(int Id, AssignmentForDisplayDto assignmentForDisplayDto, bool trackChanges);
        Task DeleteAssignmentAsync(int Id, bool trackChanges);
    }
}