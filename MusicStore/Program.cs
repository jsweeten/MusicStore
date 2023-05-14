using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Reflection.Metadata;

using var db = new GuitarContext();

/*Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new guitar");
db.Add(new Guitar { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a guitar");
var guitar = db.Guitars
    .OrderBy(g => g.GuitarId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
guitar.Url = "https://devblogs.microsoft.com/dotnet";
db.SaveChanges();


// Delete
Console.WriteLine("Delete the blog");
db.Remove(guitar);
db.SaveChanges();*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
