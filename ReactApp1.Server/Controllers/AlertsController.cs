using Contracts;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using System.Net;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertsController : ControllerBase
    {
        private ILogger<AlertsController> _logger;
        private IRepositoyWrapper _repository;
        public AlertsController(IRepositoyWrapper repository,ILogger<AlertsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAlerts()
        {
            try
            {
                
                var objalerts = _repository.Alerts.GetAlerts().ToList();
                var alerts = JsonConvert.SerializeObject(objalerts);
                _logger.LogInformation($"Returned all alerts from database.");
                return StatusCode(200, alerts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAlerts action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
