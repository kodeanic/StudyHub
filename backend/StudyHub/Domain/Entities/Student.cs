namespace Domain.Entities;

public class Student
{
    public Guid Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string Patronymic { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;
}
