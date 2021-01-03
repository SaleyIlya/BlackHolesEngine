using System;
using System.Collections.Generic;

namespace BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        private ServiceLocator() { }

        public static readonly ServiceLocator Default = new ServiceLocator();

        private readonly Dictionary<string, Func<object>> _repository = new Dictionary<string, Func<object>>();

        public ServiceLocator Register<T>(T instance) where T : class
        {
            var typeName = typeof(T).ToString();
            object Factory() { return instance; }
            _repository[typeName] = Factory;
            return this;
        }

        public ServiceLocator Register<T>(Func<T> factory) where T : class
        {
            var typeName = typeof(T).ToString();
            _repository[typeName] = factory;
            return this;
        }

        public T Resolve<T>()
        {
            var typeName = typeof(T).ToString();
            if (_repository.TryGetValue(typeName, out Func<object> factory))
            {
                return (T)factory();
            }
            throw new Exception($"{typeName} is not registered in ServiceLocator");
        }
    }
}