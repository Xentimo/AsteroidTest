using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

namespace MyInjection
{
    class InjectAttribute : Attribute
    {
    }
    
    public class IoC
    {
        Dictionary<Type, object> _instances = new Dictionary<Type, object>();
        Dictionary<Type, Type> _realtimeTypes = new Dictionary<Type,  Type>();
        
        public void RegisterInstance<T>(Type type, T instance) {
            _instances.Add(type, instance);
            _realtimeTypes.Add(type, typeof(T));
        }

        public T GetInstance<T>() 
        {
            if (!_instances.TryGetValue(typeof(T), out var instance)) {
                Debug.LogError($"Instance for type{typeof(T).Name} not registred");
                return default;
            }
            if (instance == null) {
                Debug.LogError($"Instance for type{typeof(T).Name} = null");
                return default;
            }
            return (T)instance;
        }
        
        public object GetInstance(Type t) {
            if (!_instances.TryGetValue(t, out var instance)) {
                Debug.LogError($"Instance for type{t.Name} not registred");
                return null;
            }
            if (instance == null) {
                Debug.LogError($"Instance for type{t.Name} = null");
                return null;
            }
            return instance;
        }
    
        public T InstantiateWithDepencies<T>(params object[] args) 
        {
           Type type =  typeof(T);
           ConstructorInfo[] constructorInfo =  type.GetConstructors( BindingFlags.Instance |BindingFlags.Public);
           ConstructorInfo constructor = constructorInfo[0];
           
           T obj = (T)constructor.Invoke(args);
            Inject(obj, typeof(T));
            return obj;
        }

        public void Inject<T>(T obj, Type type) {
            var fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var f  in fieldInfos) {
                if (f.GetAttribute<InjectAttribute>() != null) {
                    object instance = GetInstance(f.FieldType);
                    f.SetValue(obj, instance);
                }
            }
        }

        public void Initialize() {
            foreach (var pair in _instances) {
                var instance = pair.Value;
                Inject(instance, _realtimeTypes[pair.Key]);
            }
            foreach (var pair in _instances) {
                var instance = pair.Value;
                if(instance is IInitializable initializable)
                    initializable.Initialize();
            }
        }
        
        public void Dispose() {
            foreach (var pair in _instances) {
                var inctance = pair.Value;
                if(inctance is IDisposable disposable)
                    disposable.Dispose();
            }
        }
    }
}