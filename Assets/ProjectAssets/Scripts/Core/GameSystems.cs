using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Systems
{
    public class GameSystems
    {
        List<IUpdatedSystem> _updatedSystems = new List<IUpdatedSystem>();
        List<IInitializableSystem> _initiableSystems = new List<IInitializableSystem>();
        double _time;
        public bool isAlive { get; set; }

        public void RegisterSystem(ISystem system) {
            if(system is IInitializableSystem initiableSystem)
                _initiableSystems.Add(initiableSystem);
            if(system is IUpdatedSystem updatedSystem)
                _updatedSystems.Add(updatedSystem);
        }
        
        public void Init()
        {
            _time = 0;
            for(int i =0; i< _initiableSystems.Count;i++)
                _initiableSystems[i].Init();
            isAlive = true;
        }
        
        public void Update()
        {
            float dtime = Time.fixedDeltaTime;
            _time += dtime;
            for (int i = 0; i < _updatedSystems.Count; i++)
            {
                _updatedSystems[i].Update(_time, dtime);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < _initiableSystems.Count; i++)
                _initiableSystems[i].Clear();
            _initiableSystems.Clear();
            _updatedSystems.Clear();
            isAlive = false;
        }
    }
}