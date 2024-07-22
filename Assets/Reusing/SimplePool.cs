using System;
using System.Collections.Generic;
using UnityEngine;

namespace Reusing
{
    [Serializable]
    public class SimplePool<T>   where T : Component
    {
        int _usedCount = 0;
        public List<T> _objects;
        public List<T> _usedObjects;

        public T GetObject() {
            if (_usedCount >= _objects.Count) {
                var item = GameObject.Instantiate<T>(_objects[0], _objects[0].gameObject.transform.parent);
                _objects.Add(item);
            }

            var obj = _objects[_usedCount];
            obj.gameObject.SetActiveWithCheck(true);
            _usedObjects.Add(obj);
            _usedCount++;
            return obj;
        }

        public  void Release(T obj) {
            int newIndex = _objects.FindIndex(x => x == obj);
            if (newIndex == -1)
                return;

            int lastIndex = _usedCount - 1;
            if (newIndex < lastIndex)
                _objects.Swap(lastIndex, newIndex);
            _usedCount--;

            if (obj is IDisposable disposable)
                disposable.Dispose();
            obj.gameObject.SetActiveWithCheck(false);
            _usedObjects.Remove(obj);
        }

        public void Reset() {
            ResetUsed();
            HideUnused();
        }

        void ResetUsed() {
            _usedCount = 0;
            _objects.AddRange(_usedObjects);
            _usedObjects.Clear();
        }

        void HideUnused() {
            for (int i = _usedCount; i < _objects.Count; i++) {
                _objects[i].gameObject.SetActiveWithCheck(false);
            }
        }
    }
}