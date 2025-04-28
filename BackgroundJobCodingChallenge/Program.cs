using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BackgroundJobCodingChallenge.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<WorkerRegistry>();
builder.Services.AddSingleton<ITriggerService, MockTriggerService>();
builder.Services.AddSingleton<IQueueService, MockQueueService>();
builder.Services.AddSingleton<WorkerManager>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var workerRegistry = app.Services.GetRequiredService<WorkerRegistry>();
workerRegistry.Register(new CustomerActionWorker());
workerRegistry.Register(new EmployeeUploaderWorker());
workerRegistry.Register(new FinancialDataSyncWorker());

var workerManager = app.Services.GetRequiredService<WorkerManager>();
workerManager.StartWorkers();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

Console.WriteLine("Background Workers and API Started. Listening on localhost:5000");
app.Run("http://localhost:5000");
