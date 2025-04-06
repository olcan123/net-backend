using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

#region eski
// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container
// builder.Services.AddControllers()
//     .AddNewtonsoftJson(options =>
//     {
//         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//         options.SerializerSettings.Formatting = Formatting.Indented;
//     });

// // Autofac Service Provider Factory'yi kullan
// builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
// {
//     containerBuilder.RegisterModule(new AutofacBusinessModule());
// });

// // Add services to the container.
// builder.Services.AddRazorPages();
// builder.Services.AddControllers(); // API Controller'lar�n� aktif eder

// // CORS Politikas� Tan�mla (Do�ru Kullan�m)
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("CorsPolicy",
//         policy =>
//         {
//             policy.WithOrigins("http://localhost:5173") // Vue URL'si
//                   .AllowAnyHeader()
//                   .AllowAnyMethod();
//         });
// });

// // Swagger Deste�i Ekleyelim
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
// });

// builder.Services.AddCors();


// // JWT Authentication yap�land�rmas�
// var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = true,
//             ValidateAudience = true,
//             ValidateLifetime = true,
//             ValidIssuer = tokenOptions.Issuer,
//             ValidAudience = tokenOptions.Audience,
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
//         };
//     });




// builder.Services.AddDependencyResolvers(new ICoreModule[]
// {
//     new CoreModule()
// });

// var app = builder.Build();

// // Swagger UI Geli�tirme Ortam�nda Aktif Edildi
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
// else if (app.Environment.IsStaging())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
// else
// {

// }

// // Hata y�netimi ve g�venlik
// if (!app.Environment.IsDevelopment())
// {
//     app.ConfigureCustomExceptionMiddleware();
//     app.UseExceptionHandler("/Error");
//     app.UseHsts();
// }
// app.UseCors("CorsPolicy");
// app.UseHttpsRedirection();
// app.UseStaticFiles();

// app.UseRouting();

// // Kimlik do�rulama ve yetkilendirme middleware'leri
// app.UseAuthentication();
// app.UseAuthorization();

// app.MapRazorPages();
// app.MapControllers(); // API Controller'lar�n� etkinle�tirir

// app.Run();

#endregion

var builder = WebApplication.CreateBuilder(args);

// JSON ayarları
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Formatting = Formatting.Indented;
    });

// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacBusinessModule());
});

// Razor ve controller
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// CORS - Vue domainini buraya ekle (Render URL'ini eklemen gerek)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173", // local
            "https://vue-frontend-x5vs.onrender.com" // canlı Vue domaini (güncelle)
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// JWT Ayarı
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global hata yönetimi
if (!app.Environment.IsDevelopment())
{
    app.ConfigureCustomExceptionMiddleware();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Vue için static dosyalar
app.UseDefaultFiles(); // wwwroot/index.html otomatik açılsın
app.UseStaticFiles();  // wwwroot içeriği servis edilsin

// Middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

// Razor ve API Controller
app.MapRazorPages();
app.MapControllers();

// Vue SPA fallback → route bulunamazsa index.html dön
app.MapFallbackToFile("index.html");

app.Run();
