using AutoMapper;
using EventPlannerProject.Application.Common;
using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.Application.Exceptions;
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
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public AssignmentService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AssignmentForDisplayDto> CreateAssignementAsync(AssignmentForCreationDto assignmentForCreationDto) 
        {
            var assignmentEntity = _mapper.Map<Assignment>(assignmentForCreationDto);  //Declares a variable a variable it wants to create, and passes it to the Assignment model
            _repositoryManager.AssignmentRepository.CreateAssignment(assignmentEntity); //passing the Dto to the model.That is injecting into the model
            await _repositoryManager.SaveAsync(); //This saves the injected object

            var assignmentToReturn = _mapper.Map<AssignmentForDisplayDto>(assignmentEntity); //This declares a variable to return the created object
            return assignmentToReturn; //This returns the inserted object.
        }

        public async Task DeleteAssignmentAsync(int Id, bool trackChanges)
        {
            var FindAssignment = await _repositoryManager.AssignmentRepository.FindAssignmentByIdAsync(Id, trackChanges);
            if (FindAssignment == null)
            {
                throw new NotFoundException($"Assignment with id: {Id} not found");
            }
            _repositoryManager.AssignmentRepository.DeleteAssignment(FindAssignment);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<AssignmentForDisplayDto>> FindAllAssignmentsAsync(bool trackChanges)
        {
            var GetAssignmentEntities = await _repositoryManager.AssignmentRepository.FindAllAssignmentsAsync(trackChanges);
            var assignmentEntities = _mapper.Map<IEnumerable<AssignmentForDisplayDto>>(GetAssignmentEntities);
            return assignmentEntities;
        }

        public async Task<AssignmentForDisplayDto> FindAssignmentByIdAsync(int id, bool trackChanges)
        {
            var GetAssignment = await _repositoryManager.AssignmentRepository.FindAssignmentByIdAsync(id, trackChanges);
            if (GetAssignment == null)
            {
                throw new NotFoundException($"Assignment with id: {id} not found");
            }

            var AssignmentEntity = _mapper.Map<AssignmentForDisplayDto>(GetAssignment);
            return AssignmentEntity;
        }

        public async Task UpdateAssignmentAsync(int Id,  bool trackChanges)
        {
            var GetAssignmentDetail = await _repositoryManager.AssignmentRepository.FindAssignmentByIdAsync(Id, trackChanges);
            if (GetAssignmentDetail == null)
            {
                throw new NotFoundException($"Assignment with id: {Id} not found");
            }
            _mapper.Map<Assignment>(GetAssignmentDetail);
            await _repositoryManager.SaveAsync();
        }
    }
}
