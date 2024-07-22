using MyInjection;
using Game.Core.Systems;
using Game.World;
using UnityEngine;

public class EnemyMovingSystem : IUpdatedSystem
{
    [Inject] IWorldManager _worldManager;
    [Inject] IConfigManager _configManager;
    float _time;
    EnemiesInfo _enemiesInfo;
    public void Init()
    {
      _enemiesInfo =  _configManager.config.enemies;
    }

    public void Clear()
    {
    }

    public void Update(double t, float dt)
    {
        _time = (float)t;
        for (int i = 0; i < _worldManager.enemies.Count; i++)
        {
           EnemyEntity enemy = _worldManager.enemies[i];
           enemy.ChooseDirection(_worldManager.playerEntity, dt);
           var toTarget = (_worldManager.playerEntity.position - enemy.position);
           var toTargetDirNorm = toTarget.normalized;
           var angle = Vector3.Angle(enemy.direction, toTargetDirNorm);
           if (enemy.shotCooldown >  _enemiesInfo.shoot_cooldown && angle < _enemiesInfo.shoot_angle  && toTarget.magnitude < _enemiesInfo.shoot_distance)
               Shoot(enemy);
           else enemy.shotCooldown += dt;
           Vector3 vvector = enemy.velocity * enemy.direction + enemy.acceleration * dt;
           var pos = enemy.position + dt * vvector;
           _worldManager.ScreenTraversal(ref pos);
            enemy.position = pos;
            enemy.acceleration = Vector3.zero;
        }
    }

    void Shoot(EnemyEntity enemy)
    {
        enemy.shotCooldown = 0;
        _worldManager.AddShotEvent(new ShotEvent() {
            endPoint = enemy.position + enemy.direction,
            startPoint = enemy.position + enemy.direction, 
            direction =enemy.direction, speed = 20,
            startTime = _time, maxDistance = 13, health = 100, isEnemy = true,damage = 20
        });
    }
}
