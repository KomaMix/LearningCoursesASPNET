using LearningCourses.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Извлечение строки подключения
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// Добавление контекста базы данных в DI
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(conn));

// Добавление репозиториев
builder.Services.AddSingleton<MemoryLessonsRepository>(); // Регистрация конкретного класса
builder.Services.AddSingleton<ILessonsRepository>(sp => sp.GetRequiredService<MemoryLessonsRepository>()); // Регистрация интерфейса

// Регистрируем MemoryCoursesRepository, который зависит от MemoryLessonsRepository
builder.Services.AddSingleton<ICoursesRepository, MemoryCoursesRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
