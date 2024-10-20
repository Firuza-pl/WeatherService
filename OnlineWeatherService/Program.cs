using OnlineWeatherService.Controllers;
using ServiceReference2;
using WeatherReferences;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});

builder.Services.AddScoped<WeatherSoapServiceClient>();
builder.Services.AddScoped<UserSoapServiceClient>();


var app = builder.Build();

try
{
    app.AuthEndPoint();
	app.WeatherEndPoint();
}
catch (Exception)
{
	throw;
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
