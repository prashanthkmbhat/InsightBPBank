using System;
using ConsumerDataStandards.Infrastructure.Config;
using DbUp;

namespace ConsumerDataStandards.API.Filters
{
    /// <summary>
    /// Executes the data migration scripts and populates the configured database
    /// </summary>
    public class DatabaseInitFilter : IStartupFilter
    {
        private readonly DatabaseConfig _config;
        private readonly ILogger<DatabaseInitFilter> _logger;

        public DatabaseInitFilter(DatabaseConfig config, ILogger<DatabaseInitFilter> logger)
        {
            _config = config;
            _logger = logger;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            var connectionString = _config.ConnectionString;
            try
            {
                EnsureDatabase.For.SqlDatabase(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failing trying to ensure DB existence {0}", ex.Message);
            }

            var dbUpgradeEngineBuilder = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(typeof(Infrastructure.Repository.BankingProductRepository).Assembly)
                .WithTransaction();

            var dbUpgradeEngine = dbUpgradeEngineBuilder.Build();

            if (dbUpgradeEngine.IsUpgradeRequired())
            {
                _logger.LogInformation("Upgrades have been detected. Upgrading database now...");
                var operation = dbUpgradeEngine.PerformUpgrade();
                if (operation.Successful)
                {
                    _logger.LogInformation("Upgrade completed successfully");
                }
                else
                {
                    _logger.LogError("Error happened in the upgrade. Please check the logs");
                }
            }

            return next;
        }
    }
}

