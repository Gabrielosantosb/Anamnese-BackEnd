using AnamneseAPI.Models;
using AnamneseAPI.Services.Report;
using CatalogAPI.AppServicesExtensions;
using CatalogAPI.Models;
using CatalogAPI.Repository;
using CatalogAPI.Services.Pacient;
using CatalogAPI.Services.Token;
using CatalogAPI.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Adicione os servi�os ao cont�iner.
// Saiba mais sobre a configura��o do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAuthJWT();
builder.Services.AddCors();

#region dependecyInjection
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPacientService, PacientService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<BaseRepository<ReportModel>>();
builder.Services.AddScoped<BaseRepository<DoctorModel>>();
builder.Services.AddScoped<BaseRepository<PacientModel>>();
#endregion dependecyInjection

// Adicione o servi�o de controladores
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnamneseAPI");
        c.RoutePrefix = "swagger";
    });
}

var environment = app.Environment;

app.MapControllers();
app.UseExceptionHandling(environment).UseSwaggerMiddleware().UseAppCors();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
