using Ficha_7_Turma;
using System.Text.Json;

Turma loadTurmaJson()
{
    var jsonData = File.ReadAllText("data_turma.json");
    Turma a = JsonSerializer.Deserialize<Turma>(jsonData);
    return a;
}

Turma turma = loadTurmaJson();

Turma t = new ();

string jsonT = JsonSerializer.Serialize<Turma>(t);
File.WriteAllText("data_turma.json", jsonT);


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/Turma", () =>
{
    if (turma == null)
    {
        return Results.NotFound("Not Found!");
    }
    else
        return Results.Ok(turma.Turma_List);

});

app.MapPost("/Turma", (Aluno aluno) =>
{
    if(turma.Turma_List.Count == 0)
    {
        aluno.AlunoId = 1;
        turma.Turma_List.Add(aluno);
    }
    else
    {
        var lastaluno = turma.Turma_List[turma.Turma_List.Count - 1];
        aluno.AlunoId = lastaluno.AlunoId + 1;
        turma.Turma_List.Add(aluno);
    }
    return Results.Created("/Turma", aluno);
});

app.MapGet("/Turma/{id:int}", (int id) =>
{
    Aluno t = turma.Turma_List.Find(t => t.AlunoId == id);
    if (t == null)
    {
        return Results.NotFound("Ficha de aluno não foi encontrada.");
    }
    return Results.Ok(t);
});

app.MapDelete("/Turma/{id}", (int id) =>
{
    int removed = turma.Turma_List.RemoveAll(t => t.AlunoId == id);

    if (removed == 0)
    {
        return Results.NotFound(string.Format("Aluno: {0} não foi encontrado", id));
    }
    else
    {
        return Results.Ok(removed);
    }
});

app.MapPut("/Turma/{id}", (int id, Aluno aluno) =>
{
    var idAl = turma.Turma_List.Find(a => a.AlunoId == id);
    if (idAl == null)
    {
        return Results.NotFound($"Ficha: {id} não encontrada.");
    }
    else
    {
        idAl.Turma = aluno.Turma;
        idAl.Nome = aluno.Nome;
        idAl.Apelido = aluno.Apelido;
        idAl.Morada = aluno.Morada;
        idAl.Telemovel = aluno.Telemovel;
        idAl.Email = aluno.Email;
        return Results.Ok(idAl);
    }
});

app.MapGet("/Turma/{Morada}", (string morada) =>
{
    List<Aluno> al = turma.Turma_List.FindAll(a => a.Morada == morada);
    if(al.Count == 0)
    {
        return Results.NotFound("Morada não encontrada");
    }
    else
        return Results.Ok(al);
});
/*
app.MapGet("/Turma/{Turma}", (char tur)=>
{
    List<Aluno> t = turma.Turma_List.FindAll(a => a.Turma == tur);
    if (t.Count == 0)
    {
        return Results.NotFound("Turma não registada.");
    }
    else
        return Results.Ok(t);
});*/

app.MapGet("/Turma/download", () =>
{
    string jsonT = JsonSerializer.Serialize<Turma>(t);
    File.WriteAllText("data_turma.json", jsonT);

    try
    {
        byte[] byteArray = File.ReadAllBytes("data_turma.json");
        return Results.File(byteArray,null,"data_turma.json");
    }
    catch(FileNotFoundException t)
    {
        return Results.NotFound(t.Message);
    }
});

app.Run();
