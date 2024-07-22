
using MyInjection;
using Game.Core.Systems;
using Game.World;
public class HUDVisualizeSystem : IUpdatedSystem
{
     [Inject] IWorldManager _worldManager;
     HUDView _hudViewView;

     public HUDVisualizeSystem(HUDView hudViewView)
     {
         _hudViewView = hudViewView;
     }
     
     public void Init()
    {
       
    }

    public void Clear()
    {
        
    }

    public void Update(double t, float dt)
    {
        _hudViewView.UpdateHUD(_worldManager.playerEntity);
    }
}
