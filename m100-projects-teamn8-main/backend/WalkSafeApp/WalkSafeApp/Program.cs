using Microsoft.EntityFrameworkCore;
using WalkSafe.Application;
using WalkSafe.Core.Interfaces;
using WalkSafe.Infrastructure;
using WalkSafe.Infrastructure.Context;
using WalkSafe.Infrastructure.Converters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
// Add services to the container.
//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new ResultJsonConverter());
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000") // Replace with your frontend's URL
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<WalkSafeContext>();
        context.Database.Migrate(); // Applies any pending migrations
    }
    catch (Exception ex)
    {
        // Log the error or handle as needed
        Console.WriteLine($"An error occurred during migration: {ex.Message}");
    }
    //var dataLoaderService = scope.ServiceProvider.GetRequiredService<IDataLoaderService>();
    //await dataLoaderService.LoadDataAsync("..\\..\\WalkSafeApp\\WalkSafeApp\\Data\\park.json");
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(MyAllowSpecificOrigins);

//app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();