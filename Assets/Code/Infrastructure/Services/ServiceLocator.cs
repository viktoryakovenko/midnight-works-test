using System;
using System.Collections;
using System.Collections.Generic;

namespace Services
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> _services = new();

        public static void RegisterService<T>(T service) where T : class
        {
            _services[typeof(T)] = service;
        }

        public static IEnumerator RegisterServiceAsync<T>(T service) where T : class
        {
            yield return _services[typeof(T)] = service;
        }

        public static void UnregisterService<T>() where T : class
        {
            var type = typeof(T);

            if (_services.ContainsKey(type))
            {
                _services.Remove(type);
            }
        }

        public static T GetService<T>() where T : class
        {
            _services.TryGetValue(typeof(T), out var foundService);

            return foundService as T;
        }
    }
}
