using AutoMapper;
using BankManagementSystem.DTOs.ClientDTOs;
using BankManagementSystem.Exceptions;
using BankManagementSystem.Infrastructure.Repositories;
using BankManagementSystem.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Services;

public class ClientService(IClientRepository repository, IMapper mapper, IServiceProvider serviceProvider)
    : IClientService
{
    public IEnumerable<ClientDto> GetAll()
    {
        var clients = repository.GetAll();
            //.IgnoreQueryFilters();
        var clientsDto = mapper.Map<IEnumerable<ClientDto>>(clients);
        return clientsDto;
    }

    public ClientDto GetById(Guid id)
    {
        var serversideClient = repository.GetById(id);
        if (serversideClient is null)
            return null;

        var result = mapper.Map<ClientDto>(serversideClient);

        return result;
    }

    public (ValidationResult validationResult, ClientDto dto) Add(CreateClient createClient)
    {
        if (string.IsNullOrEmpty(createClient.FirstName))
            throw new BadRequestException("First name is required!");

        var validator = serviceProvider.GetService<IValidator<CreateClient>>();
        var result = validator.Validate(createClient);
        if (!result.IsValid)
        {
            return (result, null);
        }

        var createdClient = new Client
        {
            FirstName = createClient.FirstName,
            LastName = createClient.LastName,
            Age = createClient.Age,
            Email = createClient.Email
        };
        repository.Add(createdClient);

        var createdClientDto = mapper.Map<ClientDto>(createdClient);

        return (null, createdClientDto);
    }

    public bool TryUpdate(Guid id, UpdateClient updateClient)
    {
        var serversideClient = repository.GetById(id);
        if (serversideClient is null)
            return false;

        mapper.Map(updateClient, serversideClient);

        repository.TryUpdate(id, serversideClient);

        return true;
    }

    public bool TryUpdateSpecificProperties(Guid id, PatchUpdateClient entity)
    {
        var serversideClient = repository.GetById(id);
        if (serversideClient is null)
            return false;

        var serversideClientType = serversideClient.GetType();
        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value is not null)
            {
                var oldProperty = serversideClientType.GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serversideClient, value);
            }
        }

        repository.TryUpdate(id, serversideClient);

        return true;
    }

    public bool TryDelete(Guid id)
    {
        var deletedClient = repository.Delete(id);
        return deletedClient is not null;
    }
}