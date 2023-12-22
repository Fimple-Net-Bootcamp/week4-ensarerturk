using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Mapper;
using PetFriendTrackingAPI.Middlewares;
using PetFriendTrackingAPI.Repositories;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services;
using PetFriendTrackingAPI.Services.Contract;
using PetFriendTrackingAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PetDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IPetAnimalService, PetAnimalService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHealthStatusService, HealthStatusService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ISocialInteractionService, SocialInteractionService>();

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IPetAnimalRepository, PetAnimalRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHealthStatusRepository, HealthStatusRepository>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<ISocialInteractionRepository, SocialInteractionRepository>();

builder.Services.AddScoped<IValidator<PostUserDTO>, PostUserDTOValidator>();
builder.Services.AddScoped<IValidator<PostTrainingDTO>, PostTrainingDTOValidator>();
builder.Services.AddScoped<IValidator<PostPetAnimalDTO>, PostPetAnimalDTOValidator>();
builder.Services.AddScoped<IValidator<PostHealthStatusDTO>, PostHealthStatusDTOValidator>();
builder.Services.AddScoped<IValidator<PostFoodDTO>, PostFoodDTOValidator>();
builder.Services.AddScoped<IValidator<PostActivityDTO>, PostActivityDTOValidator>();
builder.Services.AddScoped<IValidator<PatchHealthStatusDTO>, PatchHealthStatusDTOValidator>();

builder.Services.AddAutoMapper(typeof(PetAPIMapper));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
