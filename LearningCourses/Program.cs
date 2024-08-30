using LearningCourses.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Извлечение строки подключения
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// Добавление контекста базы данных в DI
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(conn));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
