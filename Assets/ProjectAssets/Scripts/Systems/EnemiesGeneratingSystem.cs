using MyInjection;
using Game.Core.Systems;
using Game.World;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesGeneratingSystem :  IUpdatedSystem
{
    [Inject] IWorldManager _worldManager;
    [Inject] IConfigManager _configManager;
    float _enemyCooldown = 0;
    public void Init()
    {
        _worldManager.onRemoveEnemy += OnRemoveEnemy;
    }

    public void Clear()
    {
        
    }

    void OnRemoveEnemy(EnemyEntity obj)
    {
        _enemyCooldown = 0;
    }

    public void Update(double t, float dt)
    {
        if (_worldManager.enemies.Count < _configManager.config.enemies.max_enemies && _enemyCooldown > _configManager.config.enemies.cooldown)
        {
            var enemyInfo = _configManager.config.enemies;
            EnemyEntity enemyEntity = new EnemyEntity();
            enemyEntity.colliderRadius = enemyInfo.collider_radius;
            enemyEntity.velocity = Random.Range(enemyInfo.min_speed, enemyInfo.max_speed);
            float distance = Random.Range(enemyInfo.min_distance,enemyInfo.max_distance);
            float angle = Random.Range(0, 2 * Mathf.PI);
            enemyEntity.position =  new Vector3(-distance * Mathf.Cos(angle), distance * Mathf.Sin(angle), 0);
            enemyEntity.direction = new Vector3(Random.Range(-1f, 1), Random.Range(-1, 1), 0).normalized;
            enemyEntity.damage = 10;
            enemyEntity.health = 100;
            _worldManager.AddEnemy(enemyEntity);
        }
        _enemyCooldown += dt;
    }
}
