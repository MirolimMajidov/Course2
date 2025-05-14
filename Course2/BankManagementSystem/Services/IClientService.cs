using BankManagementSystem.DTOs.ClientDTOs;
using FluentValidation.Results;

namespace BankManagementSystem.Services;

public interface IClientService
{
    IEnumerable<ClientDto> GetAll();
    
    ClientDto GetById(Guid id);
    
    (ValidationResult validationResult, ClientDto dto) Add(CreateClient entity);
    
    bool TryUpdate(Guid id, UpdateClient entity);
    
    bool TryUpdateSpecificProperties(Guid id, PatchUpdateClient entity);
    
    bool TryDelete(Guid id);
}