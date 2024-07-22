using System.Collections.Generic;
using System.Linq;
using MyInjection;
using Game.Core.Systems;
using Game.World;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidGenerationSystem :  IUpdatedSystem
{
    [Inject] IWorldManager _worldManager;
    [Inject] IConfigManager _configManager;
    Config.AsteroidInfo _asteroidInfo;
    public void Init()
    {
        _asteroidInfo = _configManager.config.asteroid;
        for (int i = 0; i < _asteroidInfo.start_asteriod_count; i++)
        {
            GenerateRandomAsteroid();
          
        }
    }

    void GenerateRandomAsteroid()
    {
        int randVertCount = UnityEngine.Random.Range( _asteroidInfo.min_verts_count, _asteroidInfo.max_verts_count);
        AsteroidEntity asteroidEntity = new AsteroidEntity();
        var points = new List<Vector3>();
        float step = 2 * Mathf.PI / randVertCount;
        int randScale = Random.Range(1, 3);
        for (int k = 0; k < randVertCount; k++)
        {
            float a = k * step;
            float radius =  randScale*Random.Range( _asteroidInfo.radius_min,  _asteroidInfo.radius_max);
            var p = new Vector3(-radius * Mathf.Cos(a), radius * Mathf.Sin(a), 0);
            points.Add(p);
        }
        points.Add(points[0]);
        asteroidEntity.points = points.ToArray();
        asteroidEntity.velocity= Random.Range( _asteroidInfo.min_speed, _asteroidInfo.max_speed);
        asteroidEntity.isBig = true;
        asteroidEntity.damage = 20;
        asteroidEntity.health = 100;
        float distance = Random.Range( _asteroidInfo.min_distance,  _asteroidInfo.max_distance);
        float angle = Random.Range(0, 2 * Mathf.PI);
        asteroidEntity.position = new Vector3(distance * Mathf.Cos(angle), distance * Mathf.Sin(angle), 0);
        asteroidEntity.direction = new Vector3(Random.Range(-1f, 1), Random.Range(-1, 1), 0).normalized;
        _worldManager.AddAsteroid(asteroidEntity);
    }

    public void Clear()
    {
    }

    public void Update(double t, float dt)
    {
        if (_worldManager.asteroids.Count(x=>x.isBig) <  _asteroidInfo.min_asteriod_count)
        {
            GenerateRandomAsteroid();
        }
    }
}
