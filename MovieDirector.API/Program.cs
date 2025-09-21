using MongoDB.Driver;
using MovieDirector.API.Filters;
using MovieDirector.API.Middleware;
using MovieDirectorApp.Application.Configurations;
using MovieDirectorApp.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");
var dbName = builder.Configuration["DatabaseName"];

// Scoped olarak ekle (her request'te 1 context)
builder.Services.AddScoped<ApplicationDbContext>(sp =>
    new ApplicationDbContext(mongoConnectionString, dbName));

builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(mongoConnectionString));

builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(dbName);
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
