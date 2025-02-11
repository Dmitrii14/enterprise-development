using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Domain;
using NonResidentialFund.Server;
using NonResidentialFund.Server.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        var clientAddresses = builder.Configuration.GetSection("ClientAddresses").Get<Dictionary<string, string>>();
        if (clientAddresses == null || !clientAddresses.Any())
        {
            throw new Exception("������ 'ClientAddresses' �� ������� ��� ����� � ������������ appsettings.json.");
        }
        policy.WithOrigins(clientAddresses.Values.ToArray())
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<INonResidentialFundRepository, NonResidentialFundRepository>();

builder.Services.AddControllers();
builder.Services.AddDbContextFactory<NonResidentialFundContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("NonResidentialFund");
    optionsBuilder.UseMySQL(connectionString);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();