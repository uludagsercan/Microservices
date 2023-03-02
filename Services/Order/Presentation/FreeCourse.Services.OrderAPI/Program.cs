using FreeCourse.Services.Order.Application;
using FreeCourse.Services.Order.Application.Consumers;
using FreeCourse.Services.Order.Persistence;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddMassTransit(opt =>
{
    opt.AddConsumer<CreateOrderMessageCommandConsumer>();
    opt.AddConsumer<CourseNameChangedEventConsumer>();
    opt.UsingRabbitMq((context, cfg) =>
    {


        cfg.Host(builder.Configuration["RabbitMQSettings:Uri"], port: Convert.ToUInt16(builder.Configuration["RabbitMQSettings:Port"]), "/", host =>
        {
            host.Username(builder.Configuration["RabbitMQSettings:Username"]);
            host.Password(builder.Configuration["RabbitMQSettings:Password"]);

        });

        cfg.ReceiveEndpoint("create-order-service", e =>
        {
            e.ConfigureConsumer<CreateOrderMessageCommandConsumer>(context);
        });
        cfg.ReceiveEndpoint("course-name-changed-name-order-service", e =>
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

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
builder.Services.AddAuthorization();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "resource_order";
    options.RequireHttpsMetadata = false;
});
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationService();
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
