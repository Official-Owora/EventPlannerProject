using AutoMapper;
using EventPlannerProject.Application.Common;
using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.Domain.Models;
using EventPlannerProject.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.ServiceRepository.Service
{
    internal sealed class AssignmentService : IAssignmentService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public AssignmentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AssignmentForDisplayDto> CreateAssignementAsync(AssignmentForCreationDto assignmentForCreationDto)
        {
            var assignmentEntity = _mapper.Map<Assignment>(assignmentForCreationDto);
            _repository.AssignmentRepository.CreateAssignment(assignmentEntity);
            await _repository.SaveAsync();

            var assignmentToReturn = _mapper.Map<AssignmentForDisplayDto>(assignmentEntity);
            return assignmentToReturn;
        }

        public async Task DeleteAssignmentAsync(int Id, bool trackChanges)
        {
            var FindAssignment = await _repository.AssignmentRepository.FindAssignmentByIdAsync(Id, trackChanges);
            if (FindAssignment != null)
            {
                _repository.AssignmentRepository.DeleteAssignment(FindAssignment);
            }
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<AssignmentForDisplayDto>> FindAllAssignmentsAsync(bool trackChanges)
        {
            var GetAssignmentEntities = await _repository.AssignmentRepository.FindAllAssignmentsAsync(trackChanges);
            var assignmentEntities = _mapper.Map<IEnumerable<AssignmentForDisplayDto>>(GetAssignmentEntities);
            return assignmentEntities;
        }

        public async Task<AssignmentForDisplayDto> FindAssignmentByIdAsync(int Id, bool trackChanges)
        {
            var GetAssignment = await _repository.AssignmentRepository.FindAssignmentByIdAsync(Id, trackChanges);
            var AssignmentEntity = _mapper.Map<AssignmentForDisplayDto>(GetAssignment);
            return AssignmentEntity;
        }

        public async Task UpdateAssignmentAsync(int Id, AssignmentForUpdateDto assignmentForUpdateDto, bool trackChanges)
        {
            var GetAssignmentDetail = await _repository.AssignmentRepository.FindAssignmentByIdAsync(Id, trackChanges);
            _mapper.Map(assignmentForUpdateDto, GetAssignmentDetail);
            await _repository.SaveAsync();
        }
    }
}
