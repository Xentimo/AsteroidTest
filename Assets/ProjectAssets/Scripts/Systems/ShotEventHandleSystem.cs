
using System.Collections.Generic;
using System.Linq;
using MyInjection;
using Game.Core.Systems;
using Game.World;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;


class DistanceComparer : Comparer<Entity>
{
    public override int Compare(Entity x, Entity y)
    {
       return  x.cashedDistanceToPlayer.CompareTo(y.cashedDistanceToPlayer);
    }
}
public class ShotEventHandleSystem : IUpdatedSystem
{
    [Inject] IWorldManager _worldManager;
    [Inject] IInputManager _inputManager;
    [Inject] IConfigManager _configManager;
    Comparer<Entity> _comparer;
    double _time;
    double _lastBulletTime = 0;
    double _lastLazerTime = 0;
    public void Init()
    {
        _comparer = new DistanceComparer();
        _inputManager.GetInput().Arcada.Shot.performed += OnBulletShot;
        _inputManager.GetInput().Arcada.Lazer.performed += OnLazerShot;
    }
    
    void OnBulletShot(InputAction.CallbackContext obj)
    {
        if (( _time - _lastBulletTime) < 0.1)
            return;
        
        _lastBulletTime = _time;
        PlayerEntity playerEntity = _worldManager.playerEntity;
        _worldManager.AddShotEvent(new ShotEvent() {
            weaponType = WeaponType.Bullet,
            endPoint = playerEntity.position + playerEntity.direction,
            startPoint = playerEntity.position + playerEntity.direction, direction = playerEntity.direction, speed = 20, startTime = _time, maxDistance = 10, health = 100, damage = 20
        });
    }
    
    void OnLazerShot(InputAction.CallbackContext obj)
    {
        if ((_time - _lastLazerTime) < 0.1)
            return;

        _lastLazerTime = _time;
        if((int)_worldManager.playerEntity.lazers < 1)
            return;
        
        PlayerEntity playerEntity = _worldManager.playerEntity;
        _worldManager.AddShotEvent(new ShotEvent() {
            weaponType = WeaponType.Lazer,
            endPoint = playerEntity.position + 10 * playerEntity.direction,
            startPoint = playerEntity.position, direction = playerEntity.direction, speed = 20, startTime = _time, maxDistance = 10, health = 100,damage = 100
        });
        _worldManager.playerEntity.lazers--;
    }

    public void Update(double t, float dt)
    {
        var playerEntity = _worldManager.playerEntity;
        float rechargeSpeed = _configManager.config.player.lazer_recharge_speed;
        playerEntity.lazers +=  rechargeSpeed * dt;
        playerEntity.lazersCooldown = (Mathf.Ceil(playerEntity.lazers) - playerEntity.lazers) / rechargeSpeed;
        if (playerEntity.lazers > _configManager.config.player.max_lazers_count)
            playerEntity.lazers = _configManager.config.player.max_lazers_count;
        
        var asteroids = _worldManager.asteroids.ToList();
        var enemies = _worldManager.enemies;
        asteroids.ForEach(x=>x.cashedDistanceToPlayer = Vector3.Distance(playerEntity.position, x.position));
        asteroids.Sort(_comparer);
        var shots = _worldManager.shotEvents;

        for (int shotIndex = shots.Count-1; shotIndex >=0; shotIndex--)
        {
            var shot = shots[shotIndex];
            var shotLen = shot.speed * (float)(t - shot.startTime);
            if (shotLen > shot.maxDistance)
            {
                shot.health = 0;
                continue;
            }

            if (shot.weaponType == WeaponType.Lazer)
            {
                shot.startPoint = playerEntity.position;
                shot.direction = playerEntity.direction;
            }
            
            shot.endPoint = shot.startPoint + shotLen * shot.direction;
            if (shot.isEnemy)
            {
                if (playerEntity.Intersect(shot.endPoint))
                {
                    shot.health = 0;
                    playerEntity.health -= shot.damage;
                }
                continue;
            }

            for (int enemyIndex = 0; enemyIndex < enemies.Count; enemyIndex++)
            {
                var enemy = enemies[enemyIndex];
                if (enemy.Intersect(shot.endPoint))
                {
                    shot.health = 0;
                    enemy.health -= shot.damage;
                    playerEntity.score += 30;
                    break;
                }
            }
            for (int asteroidIndex = 0; asteroidIndex < asteroids.Count; asteroidIndex++)
            {
                var asteroid = asteroids[asteroidIndex];
                if (asteroid.Intersect(shot.startPoint, shot.endPoint))
                {
                    shot.health = 0;
                    asteroid.health -= shot.damage;
                    playerEntity.score += 20;
                    break;
                }
            }
        }

        _time = t;
    }
    
    public void Clear()
    {
        _inputManager.GetInput().Arcada.Shot.performed -= OnBulletShot;
        _inputManager.GetInput().Arcada.Lazer.performed -= OnLazerShot;
    }
}


