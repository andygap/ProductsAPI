using ProductsAPI.Infra.IoC.Extensions;
using ProductsAPI.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc(); // swagger
builder.Services.AddSqlServerConfig(builder.Configuration); //SqlServer
builder.Services.AddMongoDBConfig(builder.Configuration); //MongoDB
builder.Services.AddDependencyInjection(); //Serviços
builder.Services.AddMediatRConfig(); //MediatR
builder.Services.AddJwtBearerConfig(builder.Configuration); // JWT
builder.Services.AddCorsPolicy();  // politica de cors

var app = builder.Build();

app.UseSwaggerDoc();
app.UseCorsPolicy();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { };
