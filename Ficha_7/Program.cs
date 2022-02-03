using Ficha_7;
using System.Text.Json;
Employee employee = loadEmployeeJson();
Employees employees = loadEmployeesJson();

//função para ler o ficheiro employee.json desserializar o objeto, criar uma nova instância do tipo Employee que é e1, e devolvê-la
Employee e1 = new Employee()
{ //atribuir construtores e propriedades
    UserId = 4,
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
    UserId = 5,
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
    UserId = 6,
    JobTitle = "Driver",
    FirstName = "Ricardo",
    LastName = "Vieira",
    EmployeeCode = "ET3",
    Region = "NY",
    PhoneNumber = "25896324",
    EmailAddress = "ricardo.vieira@gmail.com"

};

//instacianr nova variavel Construtor da class object
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

app.MapGet("/employees", () =>
{
    if (employees == null)
    {
        return Results.NotFound("Not Found");
    }
    else
        return Results.Ok(employees.EmployeesList);
});

app.MapGet("/employees/{id}", (int id) =>
{
    Employee e = employees.EmployeesList.Find (e => e.UserId == id); //=> é um deleget
    /*
    Employee emp = null;
    for (int i = 0; i < employees.EmployeesList.Count; i++)
    {
        Employee e = employees.EmployeesList[i];
        if (emp.UserId == id)
        {
            e = emp;
        }
      
    }*/

    if (e == null)
    {
        return Results.NotFound("Id not Found");
    }
    return Results.Ok(e);
});

/* ou
app.MapGet("/employees", () =>
{
        return Results.Ok(employees.EmployeesList);
});*/


/*
app.MapPost("/employees", (Employees es) =>
{
    es.EmployeesList.Add(e1);
    return Results.Ok(es);
});

*/

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
    return Results.Ok(employee);
});

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

app.Run();
