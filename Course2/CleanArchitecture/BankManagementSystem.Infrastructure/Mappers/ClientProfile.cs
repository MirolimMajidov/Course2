using AutoMapper;
using BankManagementSystem.Application.DTOs.ClientDTOs;
using BankManagementSystem.Domain.Models;

namespace BankManagementSystem.Infrastructure.Mappers;

/// <summary>
/// https://docs.automapper.org/en/latest/Configuration.html#assembly-scanning-for-auto-configuration
/// </summary>
public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<CreateClient, Client>();
        CreateMap<UpdateClient, Client>();
        //.ForMember(p => p.Id, opt => opt.Ignore())
        //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName));
    }
}