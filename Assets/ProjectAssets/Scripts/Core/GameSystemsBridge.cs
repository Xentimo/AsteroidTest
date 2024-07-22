using UnityEngine;

namespace Game.Core.Systems
{
    public class GameSystemsBridge : MonoBehaviour
    {
        Link<GameSystems> _systemsContainer;
        
        void FixedUpdate() {
            if (_systemsContainer.Value == null)
                return;
            _systemsContainer.Value.Update();
        }

        public void Bind(Link<GameSystems> gameSystemsContainer) {
            _systemsContainer = gameSystemsContainer;
        }
    }
}