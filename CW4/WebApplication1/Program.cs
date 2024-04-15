// Container for configuration of the application

using Microsoft.AspNetCore.Mvc;
using WebApplication1;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Searches assembly for controllers
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build services in the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/students", () =>
{
    var student = Db.Students;
    return Results.Ok(student);
});

// GET /api/students/10
app.MapGet("/api/students/{id:int}", ([FromRoute] int id) =>
{
    var student = Db.Students.FirstOrDefault(st => st.Id == id);
    return student is null ? Results.NotFound($"Student with id {id} not found") : Results.Ok(student);
});

// POST /api/students
app.MapPost("/api/students", ([FromBody] Student data) =>
{
    var student = Db.Students.Exists(s => s.Id == data.Id);
    if (student) return Results.Conflict($"Student with id {data.Id} already exists");
    return Results.Created($"/api/students/{data.Id}", data);
});

// ----------
// GET /api/students/10/appointments
// POST /api/students/10/appointments

// GET /api/appointments?studentId=10
app.MapGet("/api/appointments", ([FromQuery] int studentId) =>
{
    return Results.Ok();
});

// Maps controllers to endpoints
app.MapControllers();

app.UseHttpsRedirection();

// Run the application on free port.
app.Run();