
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using ConsumerDataStandards.Core.IoC;
using ConsumerDataStandards.Infrastructure.IoC;
using ConsumerDataStandards.API.Filters;
using ConsumerDataStandards.Infrastructure.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddFluentValidationClientsideAdapters();
        //builder.Services.AddValidatorsFromAssemblyContaining<GetBankingProductsDtoValidator>();
        builder.Services.AddCoreServices();
        builder.Services.AddInfrastructureServices();
        builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection("DatabaseConfig"));
        builder.Services.AddTransient<IStartupFilter, DatabaseInitFilter>();
        builder.Services.AddSingleton(provider =>
        {
            var configValue = provider.GetRequiredService<IOptions<DatabaseConfig>>().Value;
            return configValue;
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
       // if (app.Environment.IsDevelopment())
        //{
            app.UseSwagger();
            app.UseSwaggerUI();
       // }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

public partial class Program { }
