namespace BlazorwasmCleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;

public class RegisterDto
{
    public bool Successful { get; set; }
    public IEnumerable<string> Errors { get; set; }
}