using AutoMapper;
using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.Application.DTOs.ForDisplayDto;
using EventPlannerProject.Application.DTOs.ForUpdateDto;
using EventPlannerProject.Domain.Models;

namespace EventPlannerProject.WebAPI
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping() 
        { 
            //Mapping for Dislay
            CreateMap<Assignment, AssignmentForDisplayDto>();
            CreateMap<Events, EventsForDisplayDto>();
            CreateMap<Participant, ParticipantForDisplayDto>();

            //Mapping for Creation
            CreateMap<AssignmentForCreationDto, Assignment>();
            CreateMap<EventsForCreationDto, Events>();
            CreateMap<ParticipantForCreationDto, Participant>();

            //Mapping for Update
            CreateMap<AssignmentForUpdateDto, Assignment>();
            CreateMap<EventsForUpdateDto, Events>();
            CreateMap<ParticipantForUpdateDto, Participant>();
        }
    }
}
