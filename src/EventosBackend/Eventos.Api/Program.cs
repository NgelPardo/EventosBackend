using Eventos.Api.Extensions;
using Eventos.Api.OptionsSetup;
using Eventos.Application;
using Eventos.Application.Abstractions.Authentication;
using Eventos.Infrastructure;
using Eventos.Infrastructure.Authentication;
using Eventos.Infrastructure.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();

builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection("GmailSettings"));

builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddTransient<IJwtProvider, JwtProvider>();

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("eventosApp", policyBuilder => 
    {
        policyBuilder.WithOrigins("http://localhost:4200");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigration();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("eventosApp");

app.Run();

