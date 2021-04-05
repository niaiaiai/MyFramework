using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace TestBase
{
    public class MyTestBase
    {
        public static readonly DbContext dbContext;
        static MyTestBase()
        {
            dbContext = DbConfig();
        }

        private static DbContext DbConfig()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();


            var options = new DbContextOptionsBuilder<MyTestContext>()
                .UseSqlServer(configuration.GetConnectionString("MyTestConnection"))
                .UseLoggerFactory(LoggerFactory.Create(logging =>
                {
                    logging.AddDebug();
                    logging.SetMinimumLevel(LogLevel.Information);
                }))
                .Options;

            MyTestContext context = new MyTestContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            for (int i = 0; i < 9999; i++)
            {
                context.MyTestEntities.Add(new MyTestEntity
                {
                    Message = $"见鬼message{i + 1}"
                });
            }
            context.SaveChanges();
            return context;
        }
    }
}
