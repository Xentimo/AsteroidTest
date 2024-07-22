using System;
using Reusing;
using UnityEngine;

public class PoolsContainer  : MonoBehaviour
{
    public AsteroidPool asteroidPool;
    public ShotPool shotPool;
    public EnemyPool enemyPool;
    public ExplosionPool explosionPool;
    public LazerPool lazerPool;
}

[Serializable]
public class AsteroidPool : SimplePool<AsteroidView>
{
    
}

[Serializable]
public class ShotPool : SimplePool<ShotView>
{
    
}


[Serializable]
public class LazerPool : SimplePool<LazerView>
{
    
}

[Serializable]
public class EnemyPool : SimplePool<EnemyView>
{
    
}



[Serializable]
public class ExplosionPool : SimplePool<ExplosionView>
{
    
}

