using LearningCourses.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ���������� ������ �����������
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

// ���������� ��������� ���� ������ � DI
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
