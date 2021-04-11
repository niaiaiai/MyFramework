using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyRepositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBase;
using Xunit;

namespace MyRepositoriesTest
{
    public class UnitOfWorkTest
    {
        private RepositoryTestClass<MyTestEntity, int> _repository;

        [Fact]
        public async Task DisposeAsync_Should_DisposeDBContext()
        {
            var context = MyTestBase.DbConfig() as MyTestContext;
            var uow = new UnitOfWork<MyTestContext>(context, Options.Create(new UnitOfWorkOptions()));
            await uow.DisposeAsync();
            
            Assert.Throws<ObjectDisposedException>(() => uow.Context.Find(typeof(MyTestEntity), 1));
        }

        [Fact]
        public async Task DisposeAsync_Should_SaveChanges()
        {
            var context = MyTestBase.DbConfig() as MyTestContext; 
            var uow = new UnitOfWork<MyTestContext>(context, Options.Create(new UnitOfWorkOptions { IsAutoCommit = true }));
            _repository = new(context);

            await _repository.InsertAsync(new MyTestEntity
            {
                Message = "00"
            });
            await uow.DisposeAsync();

            context = MyTestBase.DbConfig(false) as MyTestContext;
            _repository = new(context);

            var entity = _repository.GetAsync(item => item.Message == "00");
            Assert.NotNull(entity);
        }
    }
}
