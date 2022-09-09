using ApiBanco.Core.Interfaces;
using ApiBanco.Core.Services;
using ApiBanco.Infra.Data;
using ApiBanco.Infra.Data.Repository;
using Controller_Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();
builder.Services.AddScoped<ICadastroService, CadastroService>();
builder.Services.AddScoped<IConnectionDataBase, ConnectionDataBase>();
builder.Services.AddScoped<ValidateActionFilterByCpf>();
builder.Services.AddScoped<ValidateActionFilterUpdate>();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<GeneralExceptionFilters>();
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
