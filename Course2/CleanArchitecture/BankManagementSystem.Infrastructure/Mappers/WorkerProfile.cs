using AutoMapper;

namespace BankManagementSystem.Infrastructure.Mappers;

/// <summary>
/// https://docs.automapper.org/en/latest/Configuration.html#assembly-scanning-for-auto-configuration
/// </summary>
public class WorkerProfile : Profile
{
    public WorkerProfile()
    {
        //CreateMap<Client, ClientDto>();
    }
}