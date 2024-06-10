using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using T10.DTOs;
using T10.Services;

namespace T10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public PatientsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("{idPatient}/patient")]
        public async Task<IActionResult> GetPatientData(int IdPatient)
        {
            var patient = await _applicationService.GetPatientData(IdPatient);
            

            return Ok(patient.Select(e => new GetPatientDTO()
            {
                IdPatient = e.IdPatient,
                FirstName = e.FirstName,
                LastName = e.LastName,
                BirthDate = e.BirthDate,
            }));
        }
    }
}
