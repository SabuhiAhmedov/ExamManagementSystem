using ExamManagementSystem.Application.Abstractions;
using ExamManagementSystem.Application.Abstractions.Repositories;
using ExamManagementSystem.Application.Abstractions.Services;
using ExamManagementSystem.Persistence;
using ExamManagementSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Logic.ServiceImplementations;
using ExamManagementSystem.Application.Mappings;
using AutoMapper;
using ExamManagementSystem.Persistence.AppDbContext;
using ExamManagementSystem.BusinessLogic.ServiceImplementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddAutoMapper(typeof(ViewModelsMappings));

builder.Services.AddDbContext<ExamsDbContext>(item =>
item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));


builder.Services.AddSingleton<IUnitOfWork>
                (x => new UnitOfWork(new ExamsDbContext(
                        new DbContextOptionsBuilder<ExamsDbContext>()
                        .UseLazyLoadingProxies(true)
                        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase"))
                        .Options
                ))) ;

builder.Services.AddTransient<ILessonRepository, LessonRepository>();

builder.Services.AddTransient<ILessonService, LessonService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IExamService, ExamService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}");

app.Run();
