using T10.Models;

namespace T10.Services;

public interface IApplicationService
{
    Task<ICollection<Patient>> GetPatientData(int IdPatient);
    Task<bool> DoesPatientExist(int IdPatient);
    Task AddPatient(Patient patient);
    
    Task<bool> DoesMedicamentExist(int IdMedicament);
    
    Task<bool> DoesDoctorExist(int IdDoctor);
    
    Task AddNewPrescription(Prescription prescription);
    
    Task AddPrescriptionMedicaments(IEnumerable<PrescriptionMedicament> prescriptionMedicaments);
}