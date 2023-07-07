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
    internal sealed class OrganizerService : IOrganizerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public OrganizerService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public async Task<OrganizerForDisplayDto> CreateOrganizerAsync(OrganizerForCreationDto organizerDto)
        {
            var OrganizerEntity = _mapper.Map<Organizer>(organizerDto);
            _repositoryManager.OrganizerRepository.CreateOrganizer(OrganizerEntity);
            await _repositoryManager.SaveAsync();

            var OrganizedReturn = _mapper.Map<OrganizerForDisplayDto>(OrganizerEntity);

            return OrganizedReturn;
        }

        public async Task DeleteOrganizerAsync(int id, OrganizerForUpdateDto organizerDto, bool trackChanges)
        {
            var OrganizerToDelete = await _repositoryManager.OrganizerRepository.FindOrganizerById(id, trackChanges);
            if (OrganizerToDelete != null)
            {
                _repositoryManager.OrganizerRepository.DeleteOrganizer(OrganizerToDelete);
            }
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<OrganizerForDisplayDto>> FindAllOrganizerAsync(bool trackChanges)
        {
            var Organizers = await _repositoryManager.OrganizerRepository.FindAllOrganizersAsync(trackChanges);
            var OrganizerToReturn = _mapper.Map<IEnumerable<OrganizerForDisplayDto>>(Organizers);
            return OrganizerToReturn;
        }

        public async Task<OrganizerForDisplayDto> FindOrganizerByIdAsync(int id, bool trackChanges)
        {
            var Organizer = _repositoryManager.OrganizerRepository.FindOrganizerById(id, trackChanges);
            if(Organizer == null)
            {
                //throw an exception
            }

            var OrganizerToReturn = _mapper.Map<OrganizerForDisplayDto>(Organizer);
            return OrganizerToReturn;
        }

        public async Task UpdateOrganizerAsync(int id, bool trackChanges)
        {
            var OrganizerToUpdate = await _repositoryManager.OrganizerRepository.FindOrganizerById(id, trackChanges);
            if (OrganizerToUpdate == null)
            {
                //throw an exception
            }
             _mapper.Map<Organizer>(OrganizerToUpdate);
            await _repositoryManager.SaveAsync();
        }
    }
}
