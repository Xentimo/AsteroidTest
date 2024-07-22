using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace  Managers
{
    public class PrefabManager : IPrefabManager
    {
        private Transform _root;
        public string _path;
        public PrefabManager( Transform root, string path)
        {
            _root = root;
            _path = path;
        }
    
        public T Load<T>(string name = null) where T :  Component
        {
            var path = (name != null) ? _path + name : _path + typeof(T).Name;
            var pref = Resources.Load<T>(path);
            if (pref == null)
            {
                throw new Exception($"Cant find prefab {path}");
            }
            var obj = Object.Instantiate<T>(pref, _root);
            return obj;
        }
    }
 
}
