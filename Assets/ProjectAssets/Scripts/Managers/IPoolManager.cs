public interface  IPoolManager
{
    public AsteroidPool asteroidPool { get; }
    public ShotPool shotPool  { get; }
    public LazerPool lazerPool  { get; }
    public EnemyPool enemyPool { get; }
    public ExplosionPool explosionPool { get; }
}
