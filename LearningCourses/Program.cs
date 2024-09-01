using LearningCourses.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Извлечение строки подключения
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// Добавление контекста базы данных в DI
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(conn));

// Добавление репозиториев
//builder.Services.AddSingleton<MemoryLessonsRepository>(); // Регистрация конкретного класса
//builder.Services.AddSingleton<ILessonsRepository>(sp => sp.GetRequiredService<MemoryLessonsRepository>()); // Регистрация интерфейса

// Регистрируем MemoryCoursesRepository, который зависит от MemoryLessonsRepository
//builder.Services.AddSingleton<ICoursesRepository, MemoryCoursesRepository>();
builder.Services.AddTransient<ICoursesRepository, CoursesRepository>();
builder.Services.AddTransient<ILessonsRepository, LessonsRepository>();

var app = builder.Build();

// Применение миграции при запуске приложения
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); // Применение миграций
    }
    catch (Exception ex)
    {
        // Логирование ошибки или обработка исключения
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
