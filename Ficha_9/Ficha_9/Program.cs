using System.Diagnostics;
using System.Diagnostics.Metrics;
using Ficha_9;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/", () =>
{
    return Results.Ok("DEFAULT");

});

app.Use(async (context, next) =>
{
    Debug.WriteLine("Before First Middleware");
    await next.Invoke();
    Debug.WriteLine("After First MIddleware");
});

app.Use(async (context, next) =>
{
    Debug.WriteLine("Before Second Middleware");
    await next.Invoke();
    Debug.WriteLine("After Second Middleware");
});

app.MapDelete("/", () =>
{
    return Results.Ok("Default");
});
app.UseCustomMiddleware();
app.UseLoggerMiddleware();

app.Run();
