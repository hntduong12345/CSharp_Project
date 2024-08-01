using Microsoft.EntityFrameworkCore;
using NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Models;
using NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<ToDoDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoDB")));


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<ToDoCRUDService>();
    endpoints.MapGrpcService<AccountCRUDService>();
    endpoints.MapGrpcService<BlogCRUDService>();
    endpoints.MapGrpcService<BlogCategoryCRUDService>();

    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Communication with gRPC endpoint");
    });
});

app.Run();
