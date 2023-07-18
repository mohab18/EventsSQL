using Events;
using Events.Controllers;
using Events.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


builder.Services.AddLogging();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Events", Version = "v1" });
});
builder.Services.AddDbContext<EventDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventsDatabaseConnection"));
});
builder.Services.AddScoped<EventDataInterface, EventData>();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseExceptionHandler("/Home/Error");
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Events");
});
app.Run();
