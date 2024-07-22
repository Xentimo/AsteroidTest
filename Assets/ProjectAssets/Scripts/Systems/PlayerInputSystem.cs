using MyInjection;
using Game.Core.Systems;
using Game.World;
using Managers;
using UnityEngine.InputSystem;


public class PlayerInputSystem : IInitializableSystem
{
    [Inject] IInputManager _inputManager;
    [Inject] IWorldManager _worldManager;
 
    public void Init()
    {
        _inputManager.GetInput().Arcada.Escape.performed += OnEscape;
    }

    void OnEscape(InputAction.CallbackContext obj)
    {
        _worldManager.Escape();
    }
    public void Clear()
    {
        _inputManager.GetInput().Arcada.Escape.performed -= OnEscape;
    }
}


