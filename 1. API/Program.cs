using _1._API.Mapper;
using _2._Domain.finance.interfaces;
using _2._Domain.finance.model;
using _3._Data;
using _3._Data.context;
using _3._Data.model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injection dependencies
builder.Services.AddScoped<IFinancialTransactionData, FinancialTransactionMySqlData>();
builder.Services.AddScoped<IFinancialTransactionDomain, FinancialTransactionDomain>();

//Pomelo Mysql connection
var connectionString = builder.Configuration.GetConnectionString("FinTechDB");
builder.Services.AddDbContext<FinTechDB>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });
//Automapper
builder.Services.AddAutoMapper(
    typeof(APIToModel),
    typeof(ModelToAPI)
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<FinTechDB>())
{
    context.Database.EnsureCreated();
}

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