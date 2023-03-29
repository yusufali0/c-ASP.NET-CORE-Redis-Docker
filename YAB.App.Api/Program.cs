using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using StackExchange.Redis;
using YAB.App.Api.Redis;
using YAB.App.Infrastructure;
using YAB.App.Service;
using YAB.App.Service.Dto;
using YAB.App.Service.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddMvc();

//builder.Services.AddDistributedMemoryCache();
//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
  //  options.CheckConsentNeeded = context => true;
    //options.MinimumSameSitePolicy = SameSiteMode.None;
//});

builder.Services.AddStackExchangeRedisCache(options =>
{
    
    options.Configuration = "localhost:6379";
});

//builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



builder.Services.AddControllers();


builder.Services.AddValidatorsFromAssemblyContaining<CategoryListDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductListDtoValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<RedisService>(sp =>
{
    return new RedisService(builder.Configuration["CacheOptions:Url"]);
});

builder.Services.AddSingleton<IDatabase>(sp =>
{
    var redisService = sp.GetRequiredService<RedisService>();

    return redisService.GetDb(0);
});


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
