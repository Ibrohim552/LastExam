using System.Security.AccessControl;

namespace Infrostructure.Models;

public class Appointment
{
    public int Id { get; set; }
    public int DoctorsId { get; set; }
    public int  PatientId { get; set; }
    public DateTime AppointmentDay { get; set; }
}