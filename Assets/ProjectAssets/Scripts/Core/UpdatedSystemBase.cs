
namespace Game.Core.Systems
{
    public interface ISystem
    {
    }

    public interface IInitializableSystem : ISystem
    {
        public void Init();
        public void Clear();
    }
    
    public  interface  IUpdatedSystem : IInitializableSystem
    {
        public void Update(double t, float dt);
    }
    
}