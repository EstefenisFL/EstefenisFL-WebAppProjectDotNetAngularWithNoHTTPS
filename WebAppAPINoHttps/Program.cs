using ProjectWebData.DbContexts;
using ProjectWebData.Repositories;
using ProjectWebData.Repositories.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

builder.Services.AddSingleton<ApplicationContext>();
builder.Services.AddSingleton<SQLiteContextTests>();
builder.Services.AddSingleton<IClientService, ClientService>();
builder.Services.AddSingleton<IRepositoryClient, RepositoryClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("default");

app.UseAuthorization();

app.MapControllers();

app.Run();
