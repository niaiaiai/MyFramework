using System;

namespace MyRepositories.Repositories
{
    public interface IDataSeed
    {
        public void InitData(IServiceProvider serviceProvider);
    }
}
