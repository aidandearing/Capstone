using System.Collections.Generic;

namespace Capstone
{
    class GameObject
    {
        /// <summary>
        /// This is the list of all components this GameObject has
        /// Components are where GameObjects draw their behaviours
        /// </summary>
        private List<GameObjectComponent> components;

        /// <summary>
        /// Adds a component to the GameObject
        /// </summary>
        /// <param name="component">The component to be added</param>
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
