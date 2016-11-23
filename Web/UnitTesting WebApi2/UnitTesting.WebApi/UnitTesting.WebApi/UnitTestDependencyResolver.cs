using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace UnitTesting.WebApi
{
    public class UnitTestDependencyResolver : IDependencyResolver
    {
        private readonly Dictionary<Type, Func<object>> _factories;
        private readonly IDependencyResolver _target;

        public UnitTestDependencyResolver(IDependencyResolver target)
        {
            _factories = new Dictionary<Type, Func<object>>();
            _target = target;
        }

        public IDependencyScope BeginScope()
        {
            return new UnitTestDependencyScope(_target.BeginScope(), this);
        }

        public void Dispose()
        {
            _target.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return _target.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _target.GetServices(serviceType);
        }

        public void RegisterFactory<T>(Func<T> factory)
            where T : class

        {
            _factories.Add(typeof(T), factory);
        }

        private class UnitTestDependencyScope : IDependencyScope
        {
            private readonly UnitTestDependencyResolver _resolver;
            private readonly IDependencyScope _target;

            public UnitTestDependencyScope(IDependencyScope dependencyScope, UnitTestDependencyResolver resolver)
            {
                _resolver = resolver;
                _target = dependencyScope;
            }

            public void Dispose()
            {
                _target.Dispose();
            }

            public object GetService(Type serviceType)
            {
                Func<object> factory = null;

                if (_resolver._factories.TryGetValue(serviceType, out factory))
                {
                    return factory();
                }
                return _target.GetService(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _target.GetServices(serviceType);
            }
        }
    }
}