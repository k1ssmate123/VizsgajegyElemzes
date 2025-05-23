using VizsgajegyAPI.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ExamMarksDbContext>();
builder.Services.AddTransient<IExamMarksRepository, ExamMarksRepository>();




var app = builder.Build();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");


app.MapGet("/", () => "Hello World!");

app.UseCors(x => x
    .AllowCredentials()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://127.0.0.1:5500", "http://localhost:5500"));
app.Run();
