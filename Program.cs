
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.FiileService;
using School_Management_System.Models;
using School_Management_System.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IRepoService<Student>, StudentService>();
builder.Services.AddScoped<IRepoService<Teacher>, TeacherService>();
builder.Services.AddScoped<IRepoService<Question>, QuestionService>();
builder.Services.AddScoped<IRepoService<MSQAnswer>, MSQAnswerService>();
builder.Services.AddScoped<IRepoService<Exam>, ExamService>();
builder.Services.AddScoped<IRepoService<ExamQuestion>, ExamQuestionsService>();


builder.Services.AddScoped<IRepoService<T_OR_F_Answer>, TORFAnswerService>();



builder.Services.AddScoped<IRepoService<TeacherAttendance>, TeacherAttendanceService>();
builder.Services.AddScoped<IRepoService<StudentsAttendance>, StudentAttendanceService>();


builder.Services.AddScoped<IRepoService<Course>, CourseService>();

builder.Services.AddScoped<IFileService, FileService>();


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
         
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
