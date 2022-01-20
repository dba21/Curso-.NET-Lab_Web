using Ficha_6;
using System.Text.Json;
People people = loadJsonData(); //invocar o metodo

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

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


app.MapPost("/people", (Person person) => 
{

    people.PersonList.Add(person);
    return Results.Ok(person);

});



app.Run();

People loadJsonData()
{
    var jsonData = File.ReadAllText("data.json");
    People p = JsonSerializer.Deserialize<People>(jsonData);
    return p; //p instancia da class People
}