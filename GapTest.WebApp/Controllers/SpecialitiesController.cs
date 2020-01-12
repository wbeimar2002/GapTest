namespace GapTest.WebApp.Controllers
{
    using System.Collections.Generic;
    using GapTest.Models.Entities;
    using GapTest.Services.Clinic;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SpecialitiesController : ControllerBase
    {
        ISpecialtyService _specialtyService;

        public SpecialitiesController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        // GET: api/Specialties
        [HttpGet]
        public IEnumerable<Specialty> Get()
        {
            var result = _specialtyService.GetAll();

            return result;
        }
    }
}