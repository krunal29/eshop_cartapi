using FluentMigrator.Runner;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using eshop_cartapi.API.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region  Configure Services 

builder.Services.AddMvc();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

RegisterRequestLocalizationOptions(builder.Services);
RegisterNewtonsoftJson(builder.Services);
RegisterHangfire(builder);
RegisterSwagger(builder.Services);
RegisterCors(builder);

#endregion

var app = builder.Build();

#region Configure

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(url: "v1/swagger.json", name: "API V1");
});
app.UseHttpsRedirection();

//If uploads folder not exist then create
if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "uploads")))
{
    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "uploads"));
}

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = (context =>
    {
        context.Context.Response.Headers["Access-Control-Allow-Origin"] = "*";
    }),
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
    RequestPath = "/uploads",
    ServeUnknownFileTypes = true
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
    RequestPath = "/uploads"
});

app.UseRouting();
//Enable CORS
app.UseCors("_myAllowSpecificOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    AppPath = null,
    DashboardTitle = "Hangfire Dashboard",
    Authorization = new[] { new HangfireAuthorizationFilter() }
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard();
});

//app.Lifetime.ApplicationStarted.Register(OnStarted); //If any database call needed on start up api

app.Run();

//If any database call needed on start up api
//async void OnStarted()
//{
//    using (var unitOfWork = new UnitOfWorkHelper().GetUnitOfWork())
//    {

//    }
//}

#endregion

#region  Configure Services Functions

static void RegisterRequestLocalizationOptions(IServiceCollection services)
{
    services.AddLocalization(opt => { opt.ResourcesPath = "Resource"; });
    services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
    services.Configure<RequestLocalizationOptions>(
                                opt =>
                                {
                                    var supportedCulters = new List<CultureInfo> {
                    new CultureInfo("en"),
                    new CultureInfo("fr"),
                                };
                                    opt.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
                                    opt.SupportedCultures = supportedCulters;
                                    opt.SupportedUICultures = supportedCulters;
                                });
}

static void RegisterNewtonsoftJson(IServiceCollection services)
{
    services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
    });
}


static void RegisterHangfire(WebApplicationBuilder builder)
{
    builder.Services.AddHangfire(configuration => configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        DisableGlobalLocks = true
                    }).WithJobExpirationTimeout(TimeSpan.FromDays(7)));
    builder.Services.AddHangfireServer();
}

static void RegisterSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "V1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, new string[] { } } });
    });
}

static void RegisterCors(WebApplicationBuilder builder)
{
    var webUrl = builder.Configuration.GetSection("Urls:FrontEnd").Value;
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("_myAllowSpecificOrigins",
            builder => builder
            .WithOrigins(webUrl)
            //.SetIsOriginAllowed(origin => true) // allow any origin
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            );
    });
}



#endregion