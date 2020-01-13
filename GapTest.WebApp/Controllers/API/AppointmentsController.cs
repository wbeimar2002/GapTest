
namespace GapTest.WebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GapTest.Models.Entities;
    using GapTest.Services.Clinic;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/Appointments
        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            var result = _appointmentService.GetAll();

            return result;
        }

        // POST: api/Appointments
        [HttpPost]
        public bool Post([FromBody] Appointment value)
        {
            var result = _appointmentService.Create(value);

            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var result = _appointmentService.Remove(id);

            return result;
        }
    }
}