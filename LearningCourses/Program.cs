using LearningCourses.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���������� ������ �����������
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// ���������� ��������� ���� ������ � DI
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(conn));

// ���������� ������������
//builder.Services.AddSingleton<MemoryLessonsRepository>(); // ����������� ����������� ������
//builder.Services.AddSingleton<ILessonsRepository>(sp => sp.GetRequiredService<MemoryLessonsRepository>()); // ����������� ����������

// ������������ MemoryCoursesRepository, ������� ������� �� MemoryLessonsRepository
//builder.Services.AddSingleton<ICoursesRepository, MemoryCoursesRepository>();
builder.Services.AddTransient<ICoursesRepository, CoursesRepository>();
builder.Services.AddTransient<ILessonsRepository, LessonsRepository>();

var app = builder.Build();

// ���������� �������� ��� ������� ����������
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); // ���������� ��������
    }
    catch (Exception ex)
    {
        // ����������� ������ ��� ��������� ����������
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
