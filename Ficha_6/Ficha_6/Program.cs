using Ficha_6;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


People loadJsonData()
{
    var jsonData = File.ReadAllText("data.json");
    People p = JsonSerializer.Deserialize<People>(jsonData);
    return p; //p instancia da class People
}

People people = loadJsonData(); //invocar o metodo

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/people", () => //people nome da rota, é a lista de pessoas
{
    //return loadJsonData();
    if (people == null)
    {
        return Results.NotFound ("NOT FOUND");
    }
    else
    return Results.Ok (people);

});

app.MapPost("/people", (Person person) => //adicionar pessoa a lista
{

    people.PersonList.Add(person);
    return Results.Created("/people", person);

});

app.MapDelete("/people/{ID}", (int id) => //remover pessoa da lista, usando o for com i, remove at retira a pessoa da lista
{
    //Person person = people.PersonList.Find(p => p.ID == id);

    for (int i = 0; i < people.PersonList.Count; i++)
    {
        Person person = people.PersonList[i];
        if (person.ID == id)
        {
            people.PersonList.RemoveAt(i);
            return Results.Ok(id);
        }
    }

    return Results.NotFound($"ID: {id} not found!");
});

app.MapGet("/people/{ID}", (int id) => //people nome da rota, é a lista de pessoas
{
    
    for  (int i = 0; i < people.PersonList.Count; i++)
    {
        Person person = people.PersonList[i];
        if (person.ID == id)
        {
            return Results.Ok(person);
        }
    }

    return Results.NotFound($"ID: {id} not found!");
});


app.MapPut("/people/{ID}", (int id , Person person) =>  //alterar dados de uma pessoa // ? significa nullable, develve nulo n exite
{
    Person p = people.PersonList.Find(p => p.ID == id);
    if (p == null) {
    return Results.NotFound($"ID: {id} not found!");
    }
    else
    {
        p.FirstName = person.FirstName;
        p.LastName = person.LastName;
        p.Profession = person.Profession;
        p.Age = person.Age;
        return Results.Ok(p);
    }
});

app.Run();

