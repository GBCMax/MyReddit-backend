using Microsoft.EntityFrameworkCore;
using MyReddit.Application.Services;
using MyReddit.Core.Interfaces;
using MyReddit.DataAccess;
using MyReddit.DataAccess.Mappings;
using MyReddit.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyRedditDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MyRedditDbContext)));
});

builder.Services.AddScoped<IUserService, UsersService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostService, PostsService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ITopicService, TopicsService>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();

builder.Services.AddAutoMapper(typeof(DataBaseMappings));

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
