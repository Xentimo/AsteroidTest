using MyInjection;
using Game.Core.Systems;
using Game.World;
using Managers;
using UnityEngine;


public class PlayerCreateSystem : IInitializableSystem
{
    [Inject] IPrefabManager _prefabManager;
    [Inject] IWorldManager _worldManager;
    [Inject] IConfigManager _configManager;
    PlayerView _playerView;
    public void Init()
    {
        var playerEntity = new PlayerEntity();
        playerEntity.lazers = _configManager.config.player.max_lazers_count;
        playerEntity.colliderRadius = _configManager.config.player.collider_radius;
        playerEntity.position = Vector3.zero;
        playerEntity.direction = new Vector3(0, 1, 0);
        playerEntity.velocity = 0;
        playerEntity.acceleration = Vector3.zero;
        playerEntity.health = 100;
        _worldManager.RegisterPlayer(playerEntity);
        _playerView = _prefabManager.Load<PlayerView>();
        _playerView.Init(playerEntity);
    }

    public void Clear()
    {
        GameObject.Destroy(_playerView.gameObject);
    }
}


