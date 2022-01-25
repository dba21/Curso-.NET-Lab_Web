using Ficha_7;
using System.Text.Json;
Employee employee = loadJsonData();
Employees employees = loadJsonDataS();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();



app.MapGet("/employee", () =>
{
   if (employee != null)
    {
        return Results.NotFound("Not Found");
    }
   else
        return Results.Ok(employee);
});

app.MapGet("/employees", () =>
{
    if (employees != null)
    {
        return Results.NotFound("Not Found");
    }
    else
        return Results.Ok(employees);
});

app.Run();

Employee loadJsonData()
{
    var jsonData = File.ReadAllText("employee.json");
    Employee e = JsonSerializer.Deserialize<Employee>(jsonData);
    return e;
}

Employees loadJsonDataS()
{
    var jsonData = File.ReadAllText("employees.json");
    Employees es = JsonSerializer.Deserialize<Employees>(jsonData);
    return es;
}
