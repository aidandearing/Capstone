using System.Collections.Generic;

namespace Capstone
{
    class GameObject
    {
        private List<GameObjectComponent> components;

        public void AddComponent(GameObjectComponent component)
        {
            components.Add(component);
        }

        public Transform transform;

        public string Name { get; set; }

        public GameObject(string name)
        {
            transform = new Transform();
            Name = name;

            components = new List<GameObjectComponent>();
        }

        public void Update()
        {
            foreach (IGameObjectUpdatable component in components)
            {
                component.Update();
            }
        }

        public void Render()
        {
            foreach (IGameObjectRenderable component in components)
            {
                component.Render();
            }
        }
    }
}
