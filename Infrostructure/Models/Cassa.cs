namespace Infrostructure.Models;

public class Cassa
{
    public int Id { get; set; }
    public int PatientId { get;set; }
    public int DoctorsId { get; set; }
    public DateTime Date { get; set; }
    public double TotalPrice { get; set; }
}