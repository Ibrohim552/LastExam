using Infrostructure.Models;
namespace Infrostructure.Services.Interfaces
{
    public interface IAppointment
    {
        bool CreateAppointment(Appointment appointment);
        bool DeleteAppointment(int id);
        bool UpdateAppointment(Appointment appointment);
        Appointment GetAppointmentById(int id);
        List<Appointment> GetAppointments();
    }
}
