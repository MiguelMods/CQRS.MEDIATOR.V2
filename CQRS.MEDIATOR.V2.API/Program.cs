using CQRS.MEDIATOR.V2.API.DataContext;
using CQRS.MEDIATOR.V2.API.Filters;
using CQRS.MEDIATOR.V2.API.Models.Request;
using CQRS.MEDIATOR.V2.API.Models.Validator;
using CQRS.MEDIATOR.V2.API.Repositories.Contracs;
using CQRS.MEDIATOR.V2.API.Repositories.Implementations;
using CQRS.MEDIATOR.V2.API.Services.Contract;
using CQRS.MEDIATOR.V2.API.Services.Implementations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<RequestModelValidatorFilter>();
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDataBaseContext>(opt => { 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<ITodoItemService, TodoItemService>();
builder.Services.AddScoped<IValidator<StatusCreateRequest>, StatusCreateRequestValidator>();
builder.Services.AddScoped<IValidator<StatusUpdateRequest>, StatusUpdateRequestValidator>();
builder.Services.AddScoped<IValidator<TodoItemCreateRequest>, TodoItemCreateRequestValidator>();
builder.Services.AddScoped<IValidator<TodoItemUpdateDateRequest>, TodoItemUpdateDateRequestValidator>();
builder.Services.AddScoped<IValidator<TodoItemUpdateRequest>, TodoItemUpdateRequestValidator>();
//Mediator, copiado desde el nugget package
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
