using System;

namespace MyCore.Application
{
    public interface IApplicationInitialization
    {
        void Configure(ApplicationInitializationContext context);
    }
}
