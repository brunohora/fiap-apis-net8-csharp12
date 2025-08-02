using APIS_NET8_CSHARP12_IoC.Configurations;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.ConfigureServices();

var app = builder.Build();

app.ConfigureMiddlewares();

//app.UseExceptionHandler(errorApp =>
//{
//    errorApp.Run(async context =>
//    {
//        context.Response.StatusCode = 500;
//        context.Response.ContentType = "application/json";

//        var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
//        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

//        if (exceptionFeature?.Error != null)
//        {
//            logger.LogError(exceptionFeature.Error, exceptionFeature.Path);
//        }

//        var errorResponse = new
//        {
//            OriginalExceptionMessage = exceptionFeature?.Error?.Message,
//            NewMessage = "Ops! Ocorreu um erro interno, mas os detalhes do erro foram capturados. Vamos trabalhar para resolvê-lo o mais rápido possível."
//        };

//        await context.Response.WriteAsJsonAsync(errorResponse);
//    });
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
