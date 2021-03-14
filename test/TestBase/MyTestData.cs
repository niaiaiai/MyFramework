
using Microsoft.EntityFrameworkCore;
using MyEntity;
using MyEntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBase
{
    public class MyTestContext : DbContextBase<MyTestContext>
    {
        public MyTestContext(DbContextOptions<MyTestContext> options) : base(options) { }

        public DbSet<MyTestEntity> MyTestEntities { get; set; }
    }

    public class MyTestEntity : AggregateRoot<int>
    {
        public string Message { get; set; }
    }
}
