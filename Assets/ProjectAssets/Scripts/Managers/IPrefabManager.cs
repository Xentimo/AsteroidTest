using UnityEngine;

namespace Managers
{
    public interface IPrefabManager
    {
        public T Load<T>(string name = null) where T :  Component;
    }

}
