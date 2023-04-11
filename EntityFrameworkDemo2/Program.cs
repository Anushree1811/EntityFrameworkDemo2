//using DemoAPI.Db;
using EntityFrameworkDemo2.Db;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkDemo2.Controllers;
using EntityFrameworkDemo2.Interfaces;
using EntityFrameworkDemo2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//// using InMemory Database
//builder.Services.AddDbContext<DemoDbContext>(options =>
//    {
//        options.UseInMemoryDatabase(databaseName: "AuthorDb");
//    });

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();


// using UseSqlServer
builder.Services.AddDbContext<DemoDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Default")
    ));



builder.Services.AddControllers().AddNewtonsoftJson(options => 
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);




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

//app.MapUserEndpoints();

app.Run();
