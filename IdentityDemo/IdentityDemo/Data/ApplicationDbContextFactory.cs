using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace IdentityDemo.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            //ユーザーシークレットを取得する
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<ApplicationDbContextFactory>()
                .Build();

            //DB接続文字列を取得する
            var connStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = configuration["Db:Host"],
                Username = configuration["Db:Username"],
                Password = configuration["Db:Password"],
                Database = configuration["Db:Database"]
            };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseNpgsql(connStringBuilder.ConnectionString);

            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}
