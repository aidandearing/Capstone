using MonoEngine;

namespace Capstone
{
    abstract class Controller : GameObjectComponent, IGameObjectUpdatable
    {
        public Controller(GameObject parent) : base(parent)
        {
        }

        public abstract void Update();


    }
}
