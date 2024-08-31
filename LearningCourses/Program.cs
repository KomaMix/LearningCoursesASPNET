using LearningCourses.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ���������� ������ �����������
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// ���������� ��������� ���� ������ � DI
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(conn));

// ���������� ������������
builder.Services.AddSingleton<MemoryLessonsRepository>(); // ����������� ����������� ������
builder.Services.AddSingleton<ILessonsRepository>(sp => sp.GetRequiredService<MemoryLessonsRepository>()); // ����������� ����������

// ������������ MemoryCoursesRepository, ������� ������� �� MemoryLessonsRepository
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
