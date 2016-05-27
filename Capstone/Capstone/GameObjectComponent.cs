namespace Capstone
{
    abstract class GameObjectComponent
    {
        protected GameObject parent;

        public GameObjectComponent(GameObject parent)
        {
            this.parent = parent;
        }
    }
}
