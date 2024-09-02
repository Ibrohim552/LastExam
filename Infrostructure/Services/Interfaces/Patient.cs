namespace Infrostructure.Services.Interfaces;
using Infrostructure.Models;


    public interface IPatientService
    {
        bool CreatePatient(Patient patient);
        bool DeletePatient(int id);
        bool UpdatePatient(Patient patient);
        Patient GetPatientById(int id);
        List<Patient> GetPatients();
    }
