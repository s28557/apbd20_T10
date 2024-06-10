using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Transactions;
using System.Threading.Tasks;
using T10.DTOs;
using T10.Models;
using T10.Services;

namespace T10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public PrescriptionsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPrescription([FromBody] NewPrescriptionDTO newPrescription)
        {
            if (newPrescription.DueDate < newPrescription.Date)
            {
                return BadRequest("DueDate must be greater than or equal to Date.");
            }

            if (newPrescription.Medicaments.Count > 10)
            {
                return BadRequest("A prescription can have a maximum of 10 medications.");
            }

            if (!await _applicationService.DoesDoctorExist(newPrescription.IdDoctor))
            {
                return NotFound($"Doctor with ID - {newPrescription.IdDoctor} doesn't exist.");
            }

            var patient = newPrescription.Patient;
            if (!await _applicationService.DoesPatientExist(patient.IdPatient))
            {
                await _applicationService.AddPatient(new Patient
                {
                    IdPatient = patient.IdPatient,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    BirthDate = patient.BirthDate
                });
            }

            var prescription = new Prescription
            {
                Date = newPrescription.Date,
                DueDate = newPrescription.DueDate,
                IdPatient = patient.IdPatient,
                IdDoctor = newPrescription.IdDoctor
            };

            var prescriptionMedicaments = new List<PrescriptionMedicament>();
            foreach (var medicamentDTO in newPrescription.Medicaments)
            {
                if (!await _applicationService.DoesMedicamentExist(medicamentDTO.IdMedicament))
                {
                    return NotFound($"Medicament with ID - {medicamentDTO.IdMedicament} doesn't exist.");
                }

                prescriptionMedicaments.Add(new PrescriptionMedicament
                {
                    IdMedicament = medicamentDTO.IdMedicament,
                    IdPrescription = prescription.IdPrescription,
                    Dose = medicamentDTO.Dose,
                    Details = medicamentDTO.Description
                });
            }

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _applicationService.AddNewPrescription(prescription);
                await _applicationService.AddPrescriptionMedicaments(prescriptionMedicaments);
                scope.Complete();
            }

            return Created("api/prescriptions", new
            {
                Id = prescription.IdPrescription,
                prescription.Date,
                prescription.DueDate
            });
        }
    }
}
