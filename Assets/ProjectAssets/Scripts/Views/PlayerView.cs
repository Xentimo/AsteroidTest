
using Game.World;
using UnityEngine;

public class PlayerView  : MonoBehaviour
{
    PlayerEntity _playerEntity;
    [SerializeField] Transform rightForwardEngine;
    [SerializeField] Transform leftForwardEngine;
    [SerializeField] Transform backEngines;
  
    public void Init(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }

    public void Update()
    {
        transform.position = _playerEntity.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, _playerEntity.direction);
        rightForwardEngine.gameObject.SetActiveWithCheck(_playerEntity.acceleration.y > 0 || _playerEntity.acceleration.x < 0);
        leftForwardEngine.gameObject.SetActiveWithCheck(_playerEntity.acceleration.y > 0 || _playerEntity.acceleration.x > 0);
        backEngines.gameObject.SetActiveWithCheck(_playerEntity.acceleration.y < 0);
        
    }
}
