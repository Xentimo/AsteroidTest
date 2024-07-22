
public class PoolManager :  IPoolManager
{
    public AsteroidPool asteroidPool => _asteroidPool;
    public ShotPool shotPool => _shotPool;
    public LazerPool lazerPool => _lazerPool;
    public EnemyPool enemyPool => _enemyPool;
    public ExplosionPool explosionPool => _explosionPool;

    AsteroidPool _asteroidPool;
    ShotPool _shotPool;
    LazerPool _lazerPool;
    EnemyPool _enemyPool;
    ExplosionPool _explosionPool;

    public PoolManager(PoolsContainer poolsContainer)
    {
        _asteroidPool = poolsContainer.asteroidPool;
        _shotPool = poolsContainer.shotPool;
        _lazerPool = poolsContainer.lazerPool;
        _enemyPool = poolsContainer.enemyPool;
        _explosionPool = poolsContainer.explosionPool;
    }
}
