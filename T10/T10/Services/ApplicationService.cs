using T10.Data;
using T10.Models;
using Microsoft.EntityFrameworkCore;

namespace T10.Services;

public class ApplicationService : IApplicationService
{
    private readonly ApplicationContext _context;
    public ApplicationService(ApplicationContext context)
    {
        _context = context;
    }


    public async Task<ICollection<Patient>> GetPatientData(int IdPatient)
    {
        return await _context.Patients
            .Include(e => e.Prescriptions)
            .ThenInclude(e => e.Doctor)
            .ThenInclude(e => e.Prescriptions)
            .ThenInclude(e => e.PrescriptionMedicaments)
            .ThenInclude(e => e.Medicament)
            .Where(e => e.IdPatient == IdPatient)
            .ToListAsync();
    }

    public async Task<bool> DoesPatientExist(int IdPatient)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatient == IdPatient);
    }

    public async Task AddPatient(Patient patient)
    {
        await _context.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesMedicamentExist(int IdMedicament)
    {
        return await _context.Medicaments.AnyAsync(e => e.IdMedicament == IdMedicament);
    }

    public async Task<bool> DoesDoctorExist(int IdDoctor)
    {
        return await _context.Doctors.AnyAsync(e => e.IdDoctor == IdDoctor);
    }

    public async Task AddNewPrescription(Prescription prescription)
    {
        await _context.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task AddPrescriptionMedicaments(IEnumerable<PrescriptionMedicament> prescriptionMedicaments)
    {
        await _context.AddRangeAsync(prescriptionMedicaments);
        await _context.SaveChangesAsync();
    }
}