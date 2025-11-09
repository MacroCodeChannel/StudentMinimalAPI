using Microsoft.Extensions.Options;

namespace StudentMinimalAPI.Options
{
    public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
    {
        public readonly IConfiguration _configuration;

        public DatabaseOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DatabaseOptions options)
        {
           var connectionstring = _configuration.GetConnectionString("DefaultConnection");
            options.ConnectionString = connectionstring ?? string.Empty;
           _configuration.GetSection("DatabaseOptions").Bind(options);
        }
    }
}
