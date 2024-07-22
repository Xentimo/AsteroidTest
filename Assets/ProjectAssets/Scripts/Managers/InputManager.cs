using Managers;

public class InputManager : IInputManager
{
    GameActions _gameActions;
    public  InputManager()
    {
        _gameActions = new GameActions();
        _gameActions.Enable();
    }
    
    
    
    public GameActions GetInput()
    {
        return _gameActions;
    }
}
