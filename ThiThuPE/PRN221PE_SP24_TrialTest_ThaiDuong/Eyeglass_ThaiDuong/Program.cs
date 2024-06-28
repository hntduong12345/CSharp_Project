using Repo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStoreAccountRepo, StoreAccountRepo>();
builder.Services.AddScoped<IEyeglassesRepo, EyeglassesRepo>();
builder.Services.AddScoped<ILenTypeRepo, LenTypeRepo>();

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromHours(2);
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
