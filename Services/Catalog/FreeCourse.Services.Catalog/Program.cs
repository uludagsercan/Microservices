using Catalog.Application;
using FreeCourse.Shared;
using FreeCourse.Shared.Services;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Persistence;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
  
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSharedService();

builder.Services.AddMassTransit(opt =>
{

    opt.UsingRabbitMq((context, cfg) =>
    {
      

        cfg.Host(builder.Configuration["RabbitMQSettings:Uri"], port: Convert.ToUInt16(builder.Configuration["RabbitMQSettings:Port"]), "/", host =>
        {
            host.Username(builder.Configuration["RabbitMQSettings:Username"]);
            host.Password(builder.Configuration["RabbitMQSettings:Password"]);
        });
        cfg.ConfigurePublish(x => x.UseExecute(context2 =>
        {
            var deneme = context.GetRequiredService<IHttpContextAccessor>().HttpContext;
            context2.Headers.Set("userId", context.CreateScope().ServiceProvider.GetService<ISharedIdentityService>().GetUserId);
        }));
    });
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddPersistenceService();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "resource_catalog";
    
    options.RequireHttpsMetadata = false;
});
builder.Services.AddAuthorization(conf =>
{
    conf.AddPolicy("catalog_read", policy =>
    {
        policy.RequireClaim("scope", "catalog_readpermission", "api_full_permission");

    });
  

});


builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors();
app.Run();
