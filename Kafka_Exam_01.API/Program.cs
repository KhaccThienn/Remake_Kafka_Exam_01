
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Load AppSettings
var appSetting = AppConfiguration.LoadAppSettings(configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDerivateTradeServices(configuration);
builder.Services.AddInfrastructureRegisterService(configuration, appSetting);

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

// Seeding Data into Memory
app.LoadProductMemoryData();

app.Run();
