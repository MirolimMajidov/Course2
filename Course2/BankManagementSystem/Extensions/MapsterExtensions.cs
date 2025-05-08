using BankManagementSystem.DTOs.ClientDTOs;
using BankManagementSystem.DTOs.WorkerDTOs;
using BankManagementSystem.Models;
using Mapster;
using MapsterMapper;

namespace BankManagementSystem.Extensions;

public static class MapsterExtensions
{
    public static void AddMapster(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, Mapper>();
        var confic = TypeAdapterConfig.GlobalSettings.Default;

        confic.Config.NewConfig<CreateWorker, Worker>();
        confic.Config.NewConfig<Worker, WorkerDto>();
        confic.Config.NewConfig<UpdateClient, Client>();
        // confic.Config.NewConfig<PatchUpdateClient, Client>()
        //     .Map(dest => dest.FirstName, src => src.FirstName, e=> e.FirstName != null);
    }
}