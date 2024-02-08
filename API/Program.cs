using ClassLibrary1.Data;
using ClassLibrary1.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DBs--------------------------------------------------------------------------------------------------------
MongoCrud<About> AboutDb = new MongoCrud<About>("TestTestTest");
MongoCrud<Contact> ContactDb = new MongoCrud<Contact>("TestTestTest");
MongoCrud<Skills> SkillsDb = new MongoCrud<Skills>("TestTestTest");
MongoCrud<Education> EducationDb = new MongoCrud<Education>("TestTestTest");
MongoCrud<Qualifications> QualificationDb = new MongoCrud<Qualifications>("TestTestTest");
MongoCrud<WorkExperience> WorkexperienceDb = new MongoCrud<WorkExperience>("TestTestTest");
//DBs-end--------------------------------------------------------------------------------------------------------


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//About -------------------------------------------------------------------------------------------------
app.MapPost("/about", async (About about) =>
{
    var asd = await AboutDb.AddAsync("About", about);
    return Results.Ok(asd);
});

app.MapGet("/about", async () =>
{
    var asd = await AboutDb.GetAsync("About");
    //var aboutMe = asd.FirstOrDefault();
    return Results.Ok(asd);
});

app.MapDelete("/about/{id}", async (string id) =>
{
    try
    {
        await AboutDb.Delete<About>("About", id);
        return Results.Ok($"Product with ID: {id} has been deleted");

    }
    catch (Exception)
    {
        return Results.Problem("Something went wrong");
    }

});

app.MapPut("/about/{id}", async (string id, About UpdatedObject) =>
{
    try
    {
        await AboutDb.Update("About", UpdatedObject, id);
        return Results.Ok($"Document with {id} has been updated");
    }
    catch (Exception ex)
    {
        return Results.Problem(id, ex.Message);
    }

});

//Contact -------------------------------------------------------------------------------------------------


app.MapPost("/contact", async (Contact about) =>
{
    var asd = await ContactDb.AddAsync("Contact", about);
    return Results.Ok(asd);
});

app.MapGet("/contact", async () =>
{
    var asd = await ContactDb.GetAsync("Contact");
    return Results.Ok(asd);
});

app.MapDelete("/contact/{id}", async (string id) =>
{
    try
    {
        await ContactDb.Delete<Contact>("Contact", id);
        return Results.Ok($"Product with ID: {id} has been deleted");

    }
    catch (Exception)
    {
        return Results.Problem("Something went wrong");
    }

});

app.MapPut("/contact/{id}", async (string id, Contact UpdatedObject) =>
{
    try
    {
        await ContactDb.Update("Contact", UpdatedObject, id);
        return Results.Ok($"Document with {id} has been updated");
    }
    catch (Exception ex)
    {
        return Results.Problem(id, ex.Message);
    }

});

//Skills -------------------------------------------------------------------------------------------------
app.MapPost("/skills", async (Skills about) =>
{
    var asd = await SkillsDb.AddAsync("Skills", about);
    return Results.Ok(asd);
});

app.MapGet("/skills", async () =>
{
    var asd = await SkillsDb.GetAsync("Skills");
    return Results.Ok(asd);
});

app.MapDelete("/skills/{id}", async (string id) =>
{
    try
    {
        await SkillsDb.Delete<Skills>("Skills", id);
        return Results.Ok($"Product with ID: {id} has been deleted");

    }
    catch (Exception)
    {
        return Results.Problem("Something went wrong");
    }

});

app.MapPut("/skills/{id}", async (string id, Skills UpdatedObject) =>
{
    try
    {
        await SkillsDb.Update("Skills", UpdatedObject, id);
        return Results.Ok($"Document with {id} has been updated");
    }
    catch (Exception ex)
    {
        return Results.Problem(id, ex.Message);
    }

});

//WorkExperience -------------------------------------------------------------------------------------------------

app.MapPost("/workexperience", async (WorkExperience about) =>
{
    var asd = await WorkexperienceDb.AddAsync("WorkExperience", about);
    return Results.Ok(asd);
});

app.MapGet("/workexperience", async () =>
{
    var asd = await WorkexperienceDb.GetAsync("WorkExperience");
    return Results.Ok(asd);
});

app.MapDelete("/workexperience/{id}", async (string id) =>
{
    try
    {
        await WorkexperienceDb.Delete<WorkExperience>("WorkExperience", id);
        return Results.Ok($"Product with ID: {id} has been deleted");

    }
    catch (Exception)
    {
        return Results.Problem("Something went wrong");
    }

});

app.MapPut("/workexperience/{id}", async (string id, WorkExperience UpdatedObject) =>
{
    try
    {
        await WorkexperienceDb.Update("WorkExperience", UpdatedObject, id);
        return Results.Ok($"Document with {id} has been updated");
    }
    catch (Exception ex)
    {
        return Results.Problem(id, ex.Message);
    }

});

//qualifications -------------------------------------------------------------------------------------------------
app.MapPost("/qualifications", async (Qualifications about) =>
{
    var asd = await QualificationDb.AddAsync("Qualifications", about);
    return Results.Ok(asd);
});

app.MapGet("/qualifications", async () =>
{
    var asd = await QualificationDb.GetAsync("Qualifications");
    return Results.Ok(asd);
});

app.MapDelete("/qualifications/{id}", async (string id) =>
{
    try
    {
        await QualificationDb.Delete<Qualifications>("Qualifications", id);
        return Results.Ok($"Product with ID: {id} has been deleted");

    }
    catch (Exception)
    {
        return Results.Problem("Something went wrong");
    }

});

app.MapPut("/qualifications/{id}", async (string id, Qualifications UpdatedObject) =>
{
    try
    {
        await QualificationDb.Update("Qualifications", UpdatedObject, id);
        return Results.Ok($"Document with {id} has been updated");
    }
    catch (Exception ex)
    {
        return Results.Problem(id, ex.Message);
    }

});

//qualifications -------------------------------------------------------------------------------------------------

app.MapPost("/education", async (Education about) =>
{
    var asd = await EducationDb.AddAsync("Education", about);
    return Results.Ok(asd);
});

app.MapGet("/education", async () =>
{
    var asd = await EducationDb.GetAsync("Education");
    return Results.Ok(asd);
});

app.MapDelete("/education/{id}", async (string id) =>
{
    try
    {
        await EducationDb.Delete<Education>("Education", id);
        return Results.Ok($"Product with ID: {id} has been deleted");

    }
    catch (Exception)
    {
        return Results.Problem("Something went wrong");
    }

});

app.MapPut("/education/{id}", async (string id, Education UpdatedObject) =>
{
    try
    {
        await EducationDb.Update("Education", UpdatedObject, id);
        return Results.Ok($"Document with {id} has been updated");
    }
    catch (Exception ex)
    {
        return Results.Problem(id, ex.Message);
    }

});


app.Run();


