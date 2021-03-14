using System.Threading.Tasks;
using TestBase;
using Xunit;

namespace MyRepositoriesTest
{
    public class RepositoryTest
    {
        private RepositoryTestClass<MyTestEntity, int> _repository;
        public RepositoryTest()
        {
            _repository = new (MyTestBase.dbContext as MyTestContext);
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

        public async Task UpdateAsync_Should_Update()
        {

        }
    }
}
