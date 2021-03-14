using Microsoft.EntityFrameworkCore;
using MyRepositories.Repositories;
using System;
using TestBase;
using Xunit;

namespace MyRepositoriesTest
{
    public class RepositoryTestClass<Entity, Key> : Repository<MyTestContext, Entity, Key> where Entity : class
    {
        public RepositoryTestClass(MyTestContext context) : base(context) { }
    }
}
