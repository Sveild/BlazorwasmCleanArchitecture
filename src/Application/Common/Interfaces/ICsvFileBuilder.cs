using BlazorwasmCleanArchitecture.Application.TodoLists.Queries.ExportTodos;

namespace BlazorwasmCleanArchitecture.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
