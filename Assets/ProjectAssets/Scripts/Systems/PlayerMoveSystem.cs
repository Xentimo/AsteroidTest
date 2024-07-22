using MyInjection;
using Game.Core.Systems;
using Game.World;
using Managers;
using UnityEngine;

public class PlayerMoveSystem : IUpdatedSystem
{
    [Inject] IWorldManager _worldManager;
    [Inject] IInputManager _inputManager;
    public void Init()
    {
    }

    public void Clear()
    {
        
    }

    public void Update(double t, float dt)
    {
        PlayerEntity playerEntity = _worldManager.playerEntity;
        var movementInput = _inputManager.GetInput().Arcada.Movement.ReadValue<Vector2>();
        playerEntity.acceleration = new Vector3(movementInput.x, movementInput.y);
        playerEntity.velocity  += 2*playerEntity.acceleration.y * dt;
        playerEntity.velocity  -= 0.1f* playerEntity.velocity * playerEntity.velocity * Mathf.Sign(playerEntity.velocity) * dt;
        Vector3 vvector = playerEntity.velocity * playerEntity.direction;
        var pos = playerEntity.position + vvector * (float)dt;

        var rotationAcceleration = playerEntity.acceleration.x;
        playerEntity.moment  +=  10*rotationAcceleration * dt;
        playerEntity.moment -= 0.1f * playerEntity.moment* playerEntity.moment * Mathf.Sign(playerEntity.moment);
        playerEntity.direction = Quaternion.Euler(0, 0, -playerEntity.moment) * playerEntity.direction;
        _worldManager.ScreenTraversal(ref pos);
        playerEntity.position = pos;
    }
}
