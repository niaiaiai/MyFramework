using Microsoft.Extensions.DependencyInjection;
using MyRepositories.UnitOfWork;
using System;

namespace MyServices.Services
{
    public abstract class DomainService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected DomainService(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetService<IUnitOfWork>();
        }
    }
}
