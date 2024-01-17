using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Mttechne.Backend.Junior.Infra.Context;
using Mttechne.Backend.Junior.Interface.Configs;
using Mttechne.Backend.Junior.Services.Interfaces;
using Mttechne.Backend.Junior.Services.Notificacoes;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Produtos De Informática",
        Description = "API Lista de Produtos",
        Version = "v1"
    });

    //para ler os comentários feitos nas Actions
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
DependencyInjectionConfig.ResolveDependencies(builder.Services);

builder.Services.AddDbContext<MttechneDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var notificador = context.HttpContext.RequestServices.GetService<INotificador>();

        var erros = context.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .Select(e => new Notificacao(e.Value.Errors.FirstOrDefault()?.ErrorMessage));

        foreach (var erro in erros)
        {
            notificador.Handle(erro);
        }

        return new BadRequestObjectResult(notificador.ObterNotificacoes());
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Lista de Produtos");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();