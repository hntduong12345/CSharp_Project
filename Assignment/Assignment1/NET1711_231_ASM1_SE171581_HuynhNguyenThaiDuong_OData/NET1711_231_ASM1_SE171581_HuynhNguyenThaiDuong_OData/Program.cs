using BO.Data;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using MilkData.Models;
using Repository;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<BO.Entities.Account>("Account");
    builder.EntitySet<BO.Entities.Blog>("Blog");
    builder.EntitySet<BO.Entities.BlogCategory>("BlogCategory");
    return builder.GetEdmModel();
}

builder.Services.AddControllers().AddOData(options => options.AddRouteComponents("odata", GetEdmModel())
                                                             .Select()
                                                             .Filter()
                                                             .OrderBy()
                                                             .SetMaxTop(20)
                                                             .Count()
                                                             .Expand());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IBlogRepo, BlogRepo>();
builder.Services.AddScoped<IBlogCategoryRepo, BlogCategoryRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseODataBatching();
app.UseRouting();

app.Use((context, next) =>
{
    var endpoint = context.GetEndpoint();
    if (endpoint is null)
    {
        return next(context);
    }

    IEnumerable<string> templates;
    IODataRoutingMetadata metadata = endpoint.Metadata.GetMetadata<IODataRoutingMetadata>();

    if (metadata is not null)
    {
        templates = metadata.Template.GetTemplates();
    }

    return next(context);
});

app.UseAuthorization();

app.MapControllers();

app.Run();
