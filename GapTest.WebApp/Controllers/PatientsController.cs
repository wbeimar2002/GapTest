namespace GapTest.WebApp.Controllers
{
    using System.Collections.Generic;
    using Services.Clinic;
    using Microsoft.AspNetCore.Mvc;
    using GapTest.Models.Entities;

    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        IPatientService _patientService;


        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            var result = _patientService.GetAll();

            return result;
        }

        [HttpPost]
        public bool Post([FromBody] Patient value)
        {
            var result = _patientService.Create(value);

            return result;
        }
    }
}