using Infrostructure.Models;

namespace Infrostructure.Services.Interfaces
{
    public interface IDoctorService
    {
        bool CreateDoctor(Doctor doctor);
        bool DeleteDoctor(int id);
        bool UpdateDoctor(Doctor doctor);
        Doctor GetDoctorById(int id);
        List<Doctor> GetDoctors();
    }
}