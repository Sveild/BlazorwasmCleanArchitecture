using BlazorwasmCleanArchitecture.Application.Common.Interfaces;

namespace BlazorwasmCleanArchitecture.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
