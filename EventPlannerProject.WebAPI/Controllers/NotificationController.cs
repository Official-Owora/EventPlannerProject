using EventPlannerProject.Application.DTOs.ForCreationDto;
using EventPlannerProject.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public NotificationController(IServiceManager service)
        {
            _serviceManager = service;
        }

        [HttpPost]
        public void CreateNotification(NotificationForCreationDto notification)
        {
            _serviceManager.NotificationService.CreateNotificationAsync(notification);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotificationAsync()
        {
            var notificaitons = await _serviceManager.NotificationService.FindAllNotificationAsync(trackChanges: false);
            return Ok(notificaitons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var notification = await _serviceManager.NotificationService.FindNotificationByRecipientId(id, trackChanges: false);
            return Ok(notification);
        }

        [HttpDelete("{id}")]
        public void DeleteNotification(int id)
        {
            _serviceManager.NotificationService.DeleteNotificationAsync(id, trackChanges: false);

        }

        [HttpPut]
        public void UpdateNotification(int id)
        {
            _serviceManager.NotificationService.UpdateNotificationAsync(id, trackChanges: false);
        }

    }
}
