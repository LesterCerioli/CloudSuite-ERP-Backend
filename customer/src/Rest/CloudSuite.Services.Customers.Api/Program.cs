using AutoMapper;
using CloudSuite.Application.Services.Contracts;
using CloudSuite.Application.Services.Implementations;
using CloudSuite.Infrastructure.CrossCutting.Middlewares;
using CloudSuite.Infrastructure.Repositories;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using NetDevPack.Mediator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddMediatR();
//builder.Services.AddLogger();
//builder.Services.AddHealthCheckConfigurations();
//builder.Services.AddSwaggerDocVersion();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
//builder.Services.AddDatabaseConfiguration(builder.Configuration);

var configuration = new MapperConfiguration(cfg =>
{
});

builder.Services.AddTransient<IMediator, Mediator>();
builder.Services.AddTransient<IMediatorHandler, MediatorHandler>();
builder.Services.AddSingleton<IMapper>(configuration.CreateMapper());
//builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("my-cors",
                          policy =>
                          {
                              policy
                              .AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                          });
});


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
