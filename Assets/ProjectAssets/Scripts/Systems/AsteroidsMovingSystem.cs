using MyInjection;
using Game.Core.Systems;
using Game.World;
using UnityEngine;

public class AsteroidsMovingSystem : IUpdatedSystem
{
    [Inject] IWorldManager _worldManager;
    public void Init()
    {
    }

    public void Clear()
    {
        
    }

    public void Update(double t, float dt)
    {
        for (int i = 0; i < _worldManager.asteroids.Count; i++)
        {
           Entity a = _worldManager.asteroids[i];
           a.velocity -= 0.01f * a.velocity * a.velocity * dt * Mathf.Sign(a.velocity);
           Vector3 vvector = a.velocity * a.direction;
           var pos = a.position + dt * vvector;
            _worldManager.ScreenTraversal(ref pos);
            a.position = pos;
        }
    }
}
