using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UrfuAPI;
using UrfuAPI.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("UrfuDbConnectionString") ?? throw new InvalidOperationException("Connection string 'UrfuDbConnectionString' not found.");

        builder.Services.AddDbContext<UrfuBaseContext>(options =>{
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        }).AddTransient<UrfuBaseContext>();

// Add services to the container.

builder.Services.AddControllers();

//Тут адрес менять
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://194.87.102.61:7243",
                                                  "http://www.contoso.com")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "UrfuAPI", Version = "v1" });
        });

builder.Services.InitializeServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrfuAPI v1"));
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
