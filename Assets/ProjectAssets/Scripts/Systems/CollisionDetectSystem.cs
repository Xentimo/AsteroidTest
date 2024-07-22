using MyInjection;
using Game.Core.Systems;
using Game.World;
using UnityEngine;

public class CollisionDetectSystem : IUpdatedSystem
{
    [Inject] IWorldManager _worldManager;
    [Inject] IConfigManager _configManager;
 
    public void Init()
    {
    
    }

    public void Clear()
    {
        
    }

    public void Update(double t, float dt)
    {
        var asteroids = _worldManager.asteroids;
        var player = _worldManager.playerEntity;
 
        for (int i = 0; i < asteroids.Count; i++)
        {
            var a = asteroids[i];
            if (a.MinDistance(player.position) < player.colliderRadius)
            {
                player.health -= a.damage;
                a.health = 90;
            }
        }

        var enemies = _worldManager.enemies;
        for (int i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];
            var d = player.position - enemy.position;
            if (d.magnitude < (player.colliderRadius + enemy.colliderRadius))
            {
                enemy.direction = Vector3.Lerp(enemy.direction, player.direction, 0.75f);
                enemy.acceleration = 30*enemy.direction;
                enemy.health -= 0.4f;
                player.health -= 0.1f;
            }
        }
    }
}


