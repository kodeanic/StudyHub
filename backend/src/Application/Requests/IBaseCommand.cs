namespace Application.Requests;

public interface IBaseCommand
{
    public Guid Id { get; set; }
}
