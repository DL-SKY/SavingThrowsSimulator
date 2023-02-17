using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.StarterKIT.Services
{
    public static class ComponentLocator
    {
        public static event Action<Type> OnRegistered;
        public static event Action<Type> OnUnregistered;

        private static readonly Dictionary<Type, Component> _components = new Dictionary<Type, Component>();


        public static void Register<T>(T component) where T : Component
        {
            var type = component.GetType();
            if (_components.ContainsKey(type))
                _components[type] = component;
            else
                _components.Add(type, component);

            OnRegistered?.Invoke(type);

            Modules.StarterKIT.CustomLogger.Logger.Log(typeof(ComponentLocator), $"Register \"{type}\"");
        }

        public static void Unregister<T>() where T : Component
        {
            var type = typeof(T);
            Unregister(type);
        }

        public static void Unregister(Type type)
        {
            _components.Remove(type);

            OnUnregistered?.Invoke(type);

            Modules.StarterKIT.CustomLogger.Logger.Log(typeof(ComponentLocator), $"Unregister \"{type}\"");
        }

        public static T Resolve<T>() where T : Component
        {
            var type = typeof(T);

            if (_components.ContainsKey(type))
                return (T)_components[type];

            foreach (var key in _components.Keys)
                if (key.IsSubclassOf(type))
                    return (T)_components[key];

            return default;
        }

        public static void Clear()
        {
            _components.Clear();
        }
    }
}
