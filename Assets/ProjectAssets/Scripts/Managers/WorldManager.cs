using System;
using System.Collections.Generic;
using Game.Core.Systems;
using UnityEngine;

namespace Game.World
{
    public class WorldManager  : IWorldManager
    {
        public event Action<AsteroidEntity> onAddAsteroid;
        public event Action<AsteroidEntity> onRemoveAsteroid;

        public event Action<EnemyEntity> onAddEnemy;
        public event Action<EnemyEntity> onRemoveEnemy;
        
        public event Action<ShotEvent> onAddShot;
        public event Action<ShotEvent> onRemoveShot;

        public event Action onGameOver;
        public event Action onEscape;
        public Link<GameSystems> gameSystemsContainer { get; set; }
        public PlayerEntity playerEntity => _playerEntity;
        public IReadOnlyList<AsteroidEntity> asteroids => _asteroids;
        public IReadOnlyList<ShotEvent> shotEvents => _shots;

        public int finalScore => _finalScore;

        public IReadOnlyList<EnemyEntity> enemies => _enemies;
        List<AsteroidEntity> _asteroids = new ();
        List<EnemyEntity> _enemies = new ();
        List<ShotEvent> _shots = new();
        PlayerEntity _playerEntity;
        Rect? _worldRect;
        int _finalScore;

        public WorldManager()
        {
            gameSystemsContainer = new Link<GameSystems>();
        }
        public void AddAsteroid(AsteroidEntity entity)
        {
            _asteroids.Add(entity);
            onAddAsteroid?.Invoke(entity);
        }
        
        public void AddEnemy(EnemyEntity entity)
        {
            _enemies.Add(entity);
            onAddEnemy?.Invoke(entity);
        }
        
        public void AddShotEvent(ShotEvent shotEvent)
        {
            _shots.Add(shotEvent);
            onAddShot?.Invoke(shotEvent);
        }
        public void RegisterPlayer(PlayerEntity playerEntity)
        {
            _playerEntity = playerEntity;
        }

        Rect GetBoundingRect()
        {
            if (!_worldRect.HasValue)
            {
                float offset = 0.4f;
                var min = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0f)); 
                var max = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0f));
                _worldRect = Rect.MinMaxRect(min.x- offset, min.y-offset, max.x+offset, max.y+offset);
            }
            return _worldRect.Value;
        }

        public void ScreenTraversal(ref Vector3 pos)
        {
            Rect boundingRect = GetBoundingRect();
            if (pos.y < boundingRect.min.y)
                pos.y = boundingRect.max.y;
            if (pos.y > boundingRect.max.y)
                pos.y = boundingRect.min.y;
            if (pos.x < boundingRect.min.x)
                pos.x = boundingRect.max.x;
            if (pos.x > boundingRect.max.x)
                pos.x = boundingRect.min.x;
        }
        
        public void ClearDeads()
        {
            if (playerEntity.health <= 0)
            {
                FinalizeGame();
                onGameOver?.Invoke();
                return;
            }
            
            for (int i = _asteroids.Count - 1; i >= 0; i--)
            {
                var e = _asteroids[i];
                if (e.health <= 0)
                {
                    _asteroids.RemoveAt(i);
                    onRemoveAsteroid?.Invoke(e);
                }
            }
            
            for (int i = _shots.Count - 1; i >= 0; i--)
            {
                var s = _shots[i];
                if (s.health <= 0)
                {
                    _shots.RemoveAt(i);
                    onRemoveShot?.Invoke(s);
                }
            }
            
            for (int i = _enemies.Count - 1; i >= 0; i--)
            {
                var enemy = _enemies[i];
                if (enemy.health <= 0)
                {
                    _enemies.RemoveAt(i);
                    onRemoveEnemy?.Invoke(enemy);
                }
            }
        }

        public void Escape()
        {
            Time.timeScale = 0;
            onEscape?.Invoke();
        }

        public void Resume()
        {
            Time.timeScale = 1;
        }

        void FinalizeGame()
        {
            _finalScore = _playerEntity.score;
            _asteroids.Clear();
            _enemies.Clear();
            _shots.Clear();
            _playerEntity = null;
            gameSystemsContainer.Value.Clear();
            gameSystemsContainer.Value = null;
        }
    }
}
