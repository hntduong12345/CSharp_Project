using PRNAssignment.Services.FirebaseService;
using PRNAssignment.Services.QRCodeService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

//Add Scope
builder.Services.AddScoped<IQRCodeService, QRCodeService>();
builder.Services.AddScoped<IFirebaseService, FirebaseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Show useCors with CorsPolicyBuilder
app.UseCors(builder =>
{
    builder.WithOrigins("*")
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
