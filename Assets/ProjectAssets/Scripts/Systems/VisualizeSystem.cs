
using System.Collections.Generic;
using MyInjection;
using Game.Core.Systems;
using Game.World;
using UnityEngine;

public class VisualizeSystem : IUpdatedSystem
{
    [Inject] IWorldManager _worldManager;
    [Inject] IPoolManager _poolManager;
    Dictionary<object,UpdatedView> _views = new ();
    Transform _objectsRoot;

   public VisualizeSystem (Transform objectsRoot)
    {
        _objectsRoot = objectsRoot;
    }
    public void Init()
    {
        _worldManager.onAddAsteroid += OnAddAsteroid;
        _worldManager.onRemoveAsteroid += OnRemoveAsteroid;
        _worldManager.onAddEnemy+= OnAddEnemy;
        _worldManager.onRemoveEnemy += OnRemoveEnemy;
        _worldManager.onAddShot += OnAddShot;
        _worldManager.onRemoveShot += OnRemoveShot;
    }

    public void Clear()
    {
        _worldManager.onAddAsteroid -= OnAddAsteroid;
        _worldManager.onRemoveAsteroid -= OnRemoveAsteroid;
        _worldManager.onAddEnemy -= OnAddEnemy;
        _worldManager.onRemoveEnemy -= OnRemoveEnemy;
        _worldManager.onAddShot -= OnAddShot;
        _worldManager.onRemoveShot -= OnRemoveShot;
        _poolManager.asteroidPool.Reset();
        _poolManager.enemyPool.Reset();
        _poolManager.explosionPool.Reset();
        _poolManager.lazerPool.Reset();
        _poolManager.shotPool.Reset();
        
    }

    void OnAddShot(ShotEvent shot)
    {
        if (shot.weaponType == WeaponType.Bullet)
        {
            var view = _poolManager.shotPool.GetObject();
            view.Init(shot);
            view.transform.parent = _objectsRoot;
            _views.Add(shot, view);
        } else
        {
            var view = _poolManager.lazerPool.GetObject();
            view.Init(shot, _worldManager.playerEntity);
            view.transform.parent = _objectsRoot;
            _views.Add(shot, view);
        }
    }
    void OnRemoveShot(ShotEvent shot)
    {
        if (_views.TryGetValue(shot, out var view))
        {
            if (shot.weaponType == WeaponType.Bullet)
                _poolManager.shotPool.Release((ShotView)view);
            else
                _poolManager.lazerPool.Release((LazerView)view);
            _views.Remove(shot);
        }
    }
    void OnAddAsteroid(AsteroidEntity entity)
    {
        var view = _poolManager.asteroidPool.GetObject();
        view.Init(entity);
        view.transform.parent = _objectsRoot;
        _views.Add(entity, view);
    }
    void OnRemoveAsteroid(AsteroidEntity entity)
    {
        if (_views.TryGetValue(entity, out var view))
        {
            _poolManager.asteroidPool.Release((AsteroidView)view);
            _views.Remove(entity);
            Explode(entity.position);
        }
    }

    void Explode(Vector3 position)
    {
       var e = _poolManager.explosionPool.GetObject();
       e.transform.SetParent(_objectsRoot);
       e.transform.position = position;
       e.Explode(()=>_poolManager.explosionPool.Release(e));
    }

    void OnAddEnemy(EnemyEntity entity)
    {
        var view = _poolManager.enemyPool.GetObject();
        view.Init(entity);
        view.transform.parent = _objectsRoot;
        _views.Add(entity, view);
    }
    void OnRemoveEnemy(EnemyEntity entity)
    {
        if (_views.TryGetValue(entity, out var view))
        {
            _poolManager.enemyPool.Release((EnemyView)view);
            _views.Remove(entity);
            Explode(entity.position);
        }
    }
    
    public void Update(double t, float dt)
    {
        foreach (var v in _views)
            v.Value.UpdateView();
    }
    
}
