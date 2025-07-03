using BankManagementSystem.API.DTOs.ClientDTOs;
using FluentValidation.Results;

namespace BankManagementSystem.API.Services;

public interface IClientService
{
    IEnumerable<ClientDto> GetAll();
    
    ClientDto GetById(Guid id);
    
    (ValidationResult validationResult, ClientDto dto) Add(CreateClient entity);
    
    bool TryUpdate(Guid id, UpdateClient entity);
    
    bool TryUpdateSpecificProperties(Guid id, PatchUpdateClient entity);
    
    bool TryDelete(Guid id);
}