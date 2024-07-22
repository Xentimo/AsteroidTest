using System;
using System.Collections.Generic;
using Game.Core.Systems;
using UnityEngine;

namespace Game.World
{
    public interface IWorldManager
    {
        event Action<AsteroidEntity> onAddAsteroid;
        event Action<AsteroidEntity> onRemoveAsteroid;
        event Action<EnemyEntity> onAddEnemy;
        event Action<EnemyEntity> onRemoveEnemy;
        event Action<ShotEvent> onAddShot;
        event Action<ShotEvent> onRemoveShot;
        event Action onGameOver;
        event Action onEscape;

        public Link<GameSystems> gameSystemsContainer { get; set; }
        int finalScore { get; }

        PlayerEntity playerEntity { get; }
        IReadOnlyList<AsteroidEntity> asteroids { get; }
        IReadOnlyList<ShotEvent> shotEvents { get; }
        IReadOnlyList<EnemyEntity> enemies{ get; }
        void AddAsteroid(AsteroidEntity entity);
        void AddEnemy(EnemyEntity entity);
        void AddShotEvent(ShotEvent shotEvent);
     
        void RegisterPlayer(PlayerEntity playerEntity);
        
        void ScreenTraversal(ref Vector3 pos);

        void ClearDeads();
        void Escape();
        void Resume();
    }
}
