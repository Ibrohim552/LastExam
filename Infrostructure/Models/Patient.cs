namespace Infrostructure.Models;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public int Age { get; set; }
    public string LastName { get; set; } =null!;
    public string Email { get; set; }
}
