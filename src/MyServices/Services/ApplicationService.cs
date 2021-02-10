using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace MyServices.Services
{
    public abstract class ApplicationService : DomainService
    {
        protected readonly IMapper _mapper;
        protected ApplicationService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _mapper = serviceProvider.GetService<IMapper>();
        }
    }
}
