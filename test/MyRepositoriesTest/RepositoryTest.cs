using Microsoft.Extensions.Options;
using MyRepositories.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBase;
using Xunit;

namespace MyRepositoriesTest
{
    public class RepositoryTest
    {
        private RepositoryTestClass<MyTestEntity, int> _repository;
        private MyTestContext _context;

        public RepositoryTest()
        {
            _context = MyTestBase.dbContext as MyTestContext;
            _repository = new (_context);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(9999)]
        public async Task GetAsync_Should_GetEntity(int id)
        {
            MyTestEntity entity = await _repository.GetAsync(id);

            Assert.NotNull(entity);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(10000)]
        [InlineData(12345)]
        public async Task GetAsync_Should_Null(int id)
        {
            MyTestEntity entity = await _repository.GetAsync(id);

            Assert.Null(entity);
        }


        public async Task UpdateAsync_Should_UpdateOne()
        {

        }

        [Theory]
        [InlineData(15)]
        public async Task DeleteAsync_Should_DeleteById(int id)
        {
            await _repository.DeleteAsync(id);
            await _context.SaveChangesAsync();

            MyTestEntity entity = await _repository.GetAsync(id);
            Assert.Null(entity);
        }

        [Theory]
        [InlineData(0)]
        public async Task DeleteAsync_Should_NotDelete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        [Theory]
        [InlineData(new int[] { 20, 21, 22, 23 })]
        public async Task DeleteAsync_Should_DeleteMany(int[] ids)
        {
            var entities = await _repository.GetListAsync(item => ids.Contains(item.Id));
            await _repository.DeleteAsync(entities);
            await _context.SaveChangesAsync();

            var checkEntities = await _repository.GetListAsync(item => ids.Contains(item.Id));
            Assert.False(checkEntities.Any());
        }

        [Theory]
        [InlineData(17)]
        public async Task DeleteAsync_Should_DeleteEntity(int id)
        {
            MyTestEntity entity = await _repository.GetAsync(id);
            await _repository.DeleteAsync(entity);
            await _context.SaveChangesAsync();

            MyTestEntity checkEntity = await _repository.GetAsync(id);
            Assert.Null(checkEntity);
        }

        [Theory]
        [InlineData("7229")]
        public async Task DeleteAsync_Should_Delete(string message)
        {
            await _repository.DeleteAsync(item => item.Message.Contains(message));
            await _context.SaveChangesAsync();

            var entities = await _repository.GetListAsync(item => item.Message.Contains(message));
            Assert.False(entities.Any());
        }
    }
}
