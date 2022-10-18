using Mapster;

namespace BlazorwasmCleanArchitecture.Application.Common.Mappings;

public interface IMapFrom<T>
{
    void Mapping()
    {
        TypeAdapterConfig.GlobalSettings.ForType(typeof(T), GetType());
    }
}
