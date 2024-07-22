using MyInjection;
using Game.Core.Systems;
using Game.World;

public class HealthSystem : IUpdatedSystem
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
        var fragmentsCount = _configManager.config.asteroid.fragments_count;
        var asteroids = _worldManager.asteroids;
        for (int i = asteroids.Count - 1; i >= 0; i--)
        {
            var asteroid = asteroids[i];
            if (asteroid.health < 100)
            {
                if (asteroid.isBig && asteroid.health > 0)
                {
                    var fragmentEntities = asteroid.GenerateFragments(fragmentsCount);
                    fragmentEntities.ForEach(x=>_worldManager.AddAsteroid(x));
                }
                asteroid.health = 0;
            }
        }
        _worldManager.ClearDeads();
    }
}