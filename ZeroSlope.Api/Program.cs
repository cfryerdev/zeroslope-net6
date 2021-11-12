using Autofac;
using Autofac.Extensions.DependencyInjection;
using ZeroSlope.Api.Middleware;
using ZeroSlope.Composition;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

var settings = builder.Configuration.Get<ContainerOptions>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
{
	builder = new ContainerInstaller(settings).Install();
}));

builder.Services.AddOptions();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(x => x
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());

app.UseMiddleware<HandledResultMiddleware>();
app.UseMiddleware<AuthMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
