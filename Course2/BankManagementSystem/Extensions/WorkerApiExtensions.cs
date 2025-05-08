using BankManagementSystem.DTOs.WorkerDTOs;
using BankManagementSystem.Models;
using BankManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Extensions;

public static class WorkerApiExtensions
{
    public static void MapWorkerAPIs(this WebApplication app)
    {
        app.MapGet("api/Worker", ([FromServices] IWorkerRepository repository) =>
        {
            var workers = repository.GetAll().Select(c => c.ToDto());

            return Results.Ok(workers);
        });

        app.MapPost("api/Worker", ([FromBody] CreateWorker createWorker, [FromServices] IWorkerRepository repository) =>
        {
            if (createWorker is null)
                return Results.BadRequest("Worker is null");

            var createdWorker = new Worker
            {
                FirstName = createWorker.FirstName,
                LastName = createWorker.LastName,
                Age = createWorker.Age
            };
            repository.Add(createdWorker);

            return Results.Ok(createdWorker.ToDto());
        });
    }
}