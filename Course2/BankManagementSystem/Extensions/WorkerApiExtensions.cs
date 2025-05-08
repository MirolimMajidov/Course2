using BankManagementSystem.DTOs.WorkerDTOs;
using BankManagementSystem.Models;
using BankManagementSystem.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Extensions;

public static class WorkerApiExtensions
{
    public static void MapWorkerAPIs(this WebApplication app)
    {
        app.MapGet("api/Worker", ([FromServices] IWorkerRepository repository, 
            [FromServices] IMapper mapper) =>
        {
            var workers = repository.GetAll();
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