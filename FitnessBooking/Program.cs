using FitnessBooking.Data;
using FitnessBooking.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Razor Pages + Controllers(API)
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// EF Core (PostgureSQL)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// DI: Services
builder.Services.AddScoped<IConflictChecker, ConflictChecker>();
builder.Services.AddScoped<ISchedulingService, SchedulingService>();
builder.Services.AddScoped<IMailService, FakeMailService>(); // 学習用ダミー

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapControllers();

// DB作成＆マイグレーション適用＆初期データ投入
await DbInitializer.InitializeAsync(app.Services);

app.Run();
