using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Options;

            MyTestContext context = new MyTestContext(options);
            context.Database.EnsureCreated();
            if (!context.MyTestEntities.Any())
            {
                for(int i = 0; i < 9999; i++)
                {
                    context.MyTestEntities.Add(new MyTestEntity
                    {
                        Message = $"见鬼message{i + 1}"
                    });
                }
                context.SaveChanges();
            }
            return context;
        }
    }
}
