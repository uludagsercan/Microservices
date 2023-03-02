using FreeCourse.Services.Basket.Aplication;
using FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Consumers;
using FreeCourse.Services.Basket.Aplication.Settings;
using FreeCourse.Services.Basket.Persistence;
using FreeCourse.Shared;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
builder.Services.AddMassTransit(opt =>
{
    opt.AddConsumer<CourseNameChangedEventConsumer>();
    opt.UsingRabbitMq((context, cfg) =>
    {
     
        cfg.Host(builder.Configuration["RabbitMQSettings:Uri"], port: Convert.ToUInt16(builder.Configuration["RabbitMQSettings:Port"]), "/", host =>
        {
            host.Username(builder.Configuration["RabbitMQSettings:Username"]);
            host.Password(builder.Configuration["RabbitMQSettings:Password"]);

        });
     
        cfg.ReceiveEndpoint("course-name-changed-name-basket-service", e =>
        {
            e.ConfigureConsumer<CourseNameChangedEventConsumer>(context);
        });
    });
});
builder.Services.Configure<MassTransitHostOptions>(opt =>
{
    opt.WaitUntilStarted = true;
    opt.StartTimeout = TimeSpan.FromSeconds(30);
    opt.StopTimeout = TimeSpan.FromMinutes(1);
});
// Add services to the container.
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
builder.Services.AddAuthorization();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "resource_basket";
    options.RequireHttpsMetadata = false;
});

builder.Services.AddApplicationBasketService();
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSharedService();
builder.Services.Configure<RedisSetting>(builder.Configuration.GetSection("RedisSettings"));
builder.Services.AddBasketPersistenceService();
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

app.Run();
