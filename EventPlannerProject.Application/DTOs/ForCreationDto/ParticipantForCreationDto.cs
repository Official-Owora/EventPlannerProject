﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.DTOs.ForCreationDto
{
    public class ParticipantForCreationDto
    {
        [Required(ErrorMessage = "Participant first name is required")]
        [MaxLength(30, ErrorMessage = "Maximum length for first name is 30 characters")]
        public string? ParticipantFirstName { get; set; }

        [Required(ErrorMessage = "Participant last name is required")]
        [MaxLength(30, ErrorMessage = "Maximum length for last name is 30 characters")]
        public string? ParticipantLastName { get; set; }

        [Required(ErrorMessage = "Participant email address is required"), DataType(DataType.EmailAddress)]
        public string? ParticipantEmailAddress { get; set; }

        [Required(ErrorMessage = "Phone Number of the Assignee is required"), DataType(DataType.PhoneNumber)]
        public string? ParticipantPhoneNumber { get; set; }

        [Required(ErrorMessage = "RSVP Status is required")]
        public string? RSVPStatus { get; set; }
    }
}