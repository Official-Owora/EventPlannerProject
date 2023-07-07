﻿using AutoMapper;
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
    internal sealed class ParticipantService : IParticipantService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ParticipantService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ParticipantForDisplayDto> CreateParticipantAsync(ParticipantForCreationDto participantForCreationDto, bool trackChanges)
        {
            var participantEntity = _mapper.Map<Participant>(participantForCreationDto);
            _repository.ParticipantRepository.CreateParticipant(participantEntity);
            await _repository.SaveAsync();

            var participantToReturn = _mapper.Map<ParticipantForDisplayDto>(participantEntity);
            return participantToReturn;
        }

        public async Task DeleteParticipantAsync(int Id, bool trackChanges)
        {
            var FindParticipant = await _repository.ParticipantRepository.FindParticipantsByIdAsync(Id, trackChanges);
            if (FindParticipant != null)
            {
                _repository.ParticipantRepository.DeleteParticipant(FindParticipant);
            }
            await _repository.SaveAsync();

        }

        public async Task<IEnumerable<ParticipantForDisplayDto>> FindAllParticipantsAsync(bool trackChanges)
        {
            var GetParticipantEntities = await _repository.ParticipantRepository.FindAllParticipantsAsync(trackChanges);
            var participantEntities = _mapper.Map<IEnumerable<ParticipantForDisplayDto>>(GetParticipantEntities);
            return participantEntities;
        }

        public async Task<ParticipantForDisplayDto> FindParticipantsByIdAsync(int Id, bool trackChanges)
        {
            var GetParticipant = await _repository.ParticipantRepository.FindParticipantsByIdAsync(Id, trackChanges);
            var ParticipantEntity = _mapper.Map<ParticipantForDisplayDto>(GetParticipant);
            return ParticipantEntity;
        }

        public async Task UpdateParticipantAsync(int Id, ParticipantForUpdateDto participantForUpdateDto, bool trackChanges)
        {
            var GetParticipantDetail = await _repository.ParticipantRepository.FindParticipantsByIdAsync(Id, trackChanges);
            _mapper.Map(participantForUpdateDto, GetParticipantDetail);
            await _repository.SaveAsync();
        }
    }
}
