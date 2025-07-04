using BankManagementSystem.Application.DTOs.WorkerDTOs;
using BankManagementSystem.Application.Extensions;
using BankManagementSystem.Application.Repositories;
using BankManagementSystem.Domain.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Presentation.Extensions;

public static class WorkerApiExtensions
{
    public static void MapWorkerAPIs(this WebApplication app)
    {
        app.MapGet("api/Worker", ([FromServices] IWorkerRepository repository,
            [FromServices] IMapper mapper) =>
        {
            var workers = repository.GetAll().ToList();
            //var result = workers.Adapt<List<WorkerDto>>();
            var result = mapper.Map<List<WorkerDto>>(workers);
            //var workers = repository.GetAll().Select(c => c.ToDto());

            return Results.Ok(result);
        });

        app.MapPost("api/Worker", ([FromBody] CreateWorker createWorker,
            [FromServices] IWorkerRepository repository,
            [FromServices] IMapper mapper) =>
        {
            if (createWorker is null)
                return Results.BadRequest("Worker is null");

            // var createdWorker = createWorker.Adapt<Worker>();
            var createdWorker = mapper.Map<Worker>(createWorker);
            // var createdWorker = new Worker
            // {
            //     FirstName = createWorker.FirstName,
            //     LastName = createWorker.LastName,
            //     Age = createWorker.Age
            // };
            repository.Add(createdWorker);

            return Results.Ok(createdWorker.ToDto());
        });
    }
}