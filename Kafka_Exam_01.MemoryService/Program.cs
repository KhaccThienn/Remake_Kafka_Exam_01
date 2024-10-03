var builder = Host.CreateApplicationBuilder(args);
var configuration = builder.Configuration;

// Load AppSettings
var appSetting = AppConfiguration.LoadAppSettings(configuration);

builder.Services.AddProductProcessingServices(configuration, appSetting);

builder.Services.AddHostedService<Worker>();
// Kafka Services
builder.Services.AddKafkaServices(appSetting);

var host = builder.Build();

host.UseCustomKafkaMessageBus();

host.LoadProductMemoryData();

host.Run();
