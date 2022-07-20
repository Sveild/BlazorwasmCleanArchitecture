using System.Globalization;
using BlazorwasmCleanArchitecture.Application.Common.Interfaces;
using BlazorwasmCleanArchitecture.Application.TodoLists.Queries.ExportTodos;
using CsvHelper;
using BlazorwasmCleanArchitecture.Infrastructure.Files.Maps;

namespace BlazorwasmCleanArchitecture.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}