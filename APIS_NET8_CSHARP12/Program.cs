using APIS_NET8_CSHARP12.Models.InjecaoDependencia;
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

// ConfigureDefaultDI(builder.Services);

ConfigureKeyedDI(builder.Services);

var app = builder.Build();

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

void ConfigureDefaultDI(IServiceCollection services)
{
    services.AddSingleton<IInjecaoDependencia, InjecaoDependencia>();
    services.AddScoped<IInjecaoDependencia, InjecaoDependencia>();
    services.AddTransient<IInjecaoDependencia, InjecaoDependencia>();
}

void ConfigureKeyedDI(IServiceCollection services)
{
    services.AddKeyedSingleton<IInjecaoDependencia, InjecaoDependencia>("SingletonUm");
    services.AddKeyedSingleton<IInjecaoDependencia, InjecaoDependencia>("SingletonDois");

    services.AddKeyedScoped<IInjecaoDependencia, InjecaoDependencia>("ScopedUm");
    services.AddKeyedScoped<IInjecaoDependencia, InjecaoDependencia>("ScopedDois");

    services.AddKeyedTransient<IInjecaoDependencia, InjecaoDependencia>("TransientUm");
    services.AddKeyedTransient<IInjecaoDependencia, InjecaoDependencia>("TransientDois");
}
