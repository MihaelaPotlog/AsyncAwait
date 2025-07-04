using Microsoft.AspNetCore.Mvc;
using WebAppSample.Demos;
using WebAppSample.Demos._;
using WebAppSample.Demos.AsyncEnumerator;
using WebAppSample.Demos.CancellationTokenDemo;
using WebAppSample.Exercise;
using WebAppSample.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IActivitiesService, ActivitiesService>();
builder.Services.AddScoped<IPrimeNumberAlgorithm, PrimeNumberAlgorithm>();
builder.Services.AddScoped<ICompletePrimeNumberAlgorithm, CompletePrimeNumberAlgorithm>();
builder.Services.AddScoped<IUsersDataProcessor, UsersDataProcessor>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Logging.AddConsole();

var app = builder.Build();
app.UseMiddleware<OperationCancelledMiddleware>();

#region Exercise
//Having an endpoint that receives a number as query parameter,
//use CancellationToken to respond to the cancellation issued when the user resends the request.
///isPrime?number=67280421310721
app.MapGet("/isPrime", ([FromQuery] ulong number, IPrimeNumberAlgorithm primeNumberAlgorithm, CancellationToken token) =>
{
    app.Logger.LogInformation("Starting to check if is prime");

    // expensive synchronous operation
    var isPrime = primeNumberAlgorithm.IsPrime(number);

    return isPrime ? $"{number} is prime" : $"{number} is NOT prime";
});
#endregion

#region Demos
//Demo - Cancellation token
app.MapGet("/activities", async (CancellationToken token, IActivitiesService activitiesService) =>
{
    app.Logger.LogInformation("Starting to do slow work");

    // slow async action, e.g. call external api
    var activities = await activitiesService.GetActivitiesAsync(token);

    app.Logger.LogInformation("Finished to do slow work");

    return $"{DateTime.Now}: {string.Join(", ", activities)}";
});

//Demo - async streams
app.MapGet("/users", async (IUsersDataProcessor usersDataProcessor, CancellationToken token) =>
{
    await usersDataProcessor.ProcessUsersDataAsync();

    return "Processed";
});

#endregion

app.Run();