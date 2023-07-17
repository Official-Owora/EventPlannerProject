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
            CreateMap<Organizer, OrganizerForDisplayDto>();
            CreateMap<Notification, NotificationForDisplayDto>();

            //Mapping for Creation
            CreateMap<AssignmentForCreationDto, Assignment>();
            CreateMap<EventsForCreationDto, Events>();
            CreateMap<OrganizerForCreationDto, Organizer>();
            CreateMap<NotificationForCreationDto, Notification>();

            //Mapping for Update
            CreateMap<AssignmentForUpdateDto, Assignment>();
            CreateMap<EventsForUpdateDto, Events>();
            CreateMap<OrganizerForUpdateDto, Organizer>();
            CreateMap<NotificationForUpdateDto, Notification>();
        }
    }
}
