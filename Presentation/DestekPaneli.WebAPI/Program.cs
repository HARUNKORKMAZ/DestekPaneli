using Carter;
using DestekPaneli.Application.Interfaces.Repositories;
using DestekPaneli.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.Services.AddCarter();
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    string con = builder.Configuration.GetConnectionString("SqlServer");
    opt.UseSqlServer(con);
});
builder.Services.AddScoped<IAuthService, IAuthService>();
builder.Services.AddScoped<ITicketService, ITicketService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();


app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod()
.SetPreflightMaxAge(TimeSpan.FromMinutes(10))
);
app.MapCarter();




app.Run();