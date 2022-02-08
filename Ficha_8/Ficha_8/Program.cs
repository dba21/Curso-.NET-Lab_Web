using Ficha_8;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Employee loadEmployeeJson()
{
    var jsonData = File.ReadAllText("employee.json");
    Employee e = JsonSerializer.Deserialize<Employee>(jsonData);
    return e;
}

Employees loadEmployeesJson()
{
    var jsonData = File.ReadAllText("employees.json");
    Employees es = JsonSerializer.Deserialize<Employees>(jsonData);
    return es;
}

Employee employee = loadEmployeeJson();
Employees employees = loadEmployeesJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Mostra toda lista dos Funcionarios
app.MapGet("/employees", () =>
{
    if (employees == null)
    {
        return Results.NotFound("Not Found");
    }
    else
        return Results.Ok(employees.EmployeesList);
});

//Mostra os dados de um funcionario
app.MapGet("/employees/{id:int}", (int id) =>
{
    Employee e = employees.EmployeesList.Find(e => e.UserId == id);

    if (e == null)
    {
        return Results.NotFound("Id not Found");
    }
    return Results.Ok(e);
});

//Remove os dados de um funcionario
app.MapDelete("/employees/{id}", (int id) =>
{
    int removed = employees.EmployeesList.RemoveAll(e1 => e1.UserId == id);

    if (removed == 0)
    {
        return Results.NotFound(string.Format("Id: {0} not found", id));

    }
    else
    {
        return Results.Ok(removed);
    }

});

//Adicionar um novo funcionario a lista
app.MapPost("/employees", (Employee employee) =>
{
    //var firstEmp = employees.EmployeesList.FirstOrDefault();

    if (employees.EmployeesList.Count == 0)
    {
        employee.UserId = 1; //esta linha esta a definir 
        employees.EmployeesList.Add(employee);

    }
    else
    {
        var lastEmp = employees.EmployeesList[employees.EmployeesList.Count - 1];  //ir a lista e selecionar o ultimo funcionario
        //var lastEmp = employees.EmployeesList.LastOrDefault(); 
        employee.UserId = lastEmp.UserId + 1;
        employees.EmployeesList.Add(employee); //guarda o funcionario ad na lista
    }
    return Results.Created("/employees", employee);
});

//Alterar os dados de um funcionario
app.MapPut("/employees/{id}", (int id, Employee employee) =>
{
    var emp = employees.EmployeesList.Find(e => e.UserId == id);
    if (emp == null)
    {
        return Results.NotFound($"ID : {id} not found!");
    }
    else
    {
        emp.JobTitle = employee.JobTitle;
        emp.FirstName = employee.FirstName;
        emp.LastName = employee.LastName;
        emp.EmployeeCode = employee.EmployeeCode;
        emp.Region = employee.Region;
        emp.PhoneNumber = employee.PhoneNumber;
        emp.EmailAddress = employee.EmailAddress;
        return Results.Ok(emp);
    }
});

//Mostra os dados dos funcionarios por região
app.MapGet("/employees/{Region}", (string region) =>
{
    List<Employee> emps = employees.EmployeesList.FindAll(e => e.Region == region);

    if (emps.Count == 0) //Se a região não for encontrata mostra return em [] (da lista vazia)
    {
        return Results.NotFound("Id not Found");
    }
    else
        return Results.Ok(emps);
});

//Fazer o download da lista de funcionarios do ficheiro JSON
app.MapGet("/employees/download", () =>
{
    //Guardar a lista atual de funcionarios num ficheiro
    string jsonS = JsonSerializer.Serialize<Employees>(employees);
    File.WriteAllText("testEmployees.json", jsonS);

    try
    {
        byte[] byteArray = File.ReadAllBytes("employees.json");
        return Results.File(byteArray, null, "employees.json");
    }
    catch (FileNotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
});



app.Run();
