using System;

namespace BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator
{
    public interface IServiceLocator
    {
        ServiceLocator Register<T>(T instance) where T : class;
        ServiceLocator Register<T>(Func<T> factory) where T : class;
        T Resolve<T>();
    }
}