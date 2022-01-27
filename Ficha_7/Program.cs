using Ficha_7;
using System.Text.Json;
Employee employee = loadEmployeeJson();
Employees employees = loadEmployeesJson();

//função para ler o ficheiro employee.json desserializar o objeto, criar uma nova instância do tipo Employee que é e1, e devolvê-la
Employee e1 = new Employee()
{ //atribuir construtores e propriedades
    UserId = " 1",
    JobTitle = "Teacher",
    FirstName = "Tiago",
    LastName =  "Nunes",
    EmployeeCode = "ET1",
    Region = "NY",
    PhoneNumber = "98756633",
    EmailAddress = "tiago.nunes@gmail.com"

};

Employee e2 = new Employee
{
    UserId = " 2",
    JobTitle = "Student",
    FirstName = "Marta",
    LastName = "Abreu",
    EmployeeCode = "ET2",
    Region = "NY",
    PhoneNumber = "98756633",
    EmailAddress = "marta.abreu@gmail.com"

};

Employee e3 = new Employee
{
    UserId = " 3",
    JobTitle = "Driver",
    FirstName = "Ricardo",
    LastName = "Vieira",
    EmployeeCode = "ET3",
    Region = "NY",
    PhoneNumber = "25896324",
    EmailAddress = "ricardo.vieira@gmail.com"

};

//Construtor da class object
Employees es = new Employees();

es.EmployeesList.Add(e1);
es.EmployeesList.Add(e2);
es.EmployeesList.Add(e3);

string json = JsonSerializer.Serialize<Employee>(e1);
string jsonS = JsonSerializer.Serialize<Employees>(es);
File.WriteAllText("test.json", json);
File.WriteAllText("testEmployees.json", jsonS);




//Serializar é Instancias para json
//desserializar é json para Instancias
//Employee é a class, e1 é instancia, new Employee(); é o construtor




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
