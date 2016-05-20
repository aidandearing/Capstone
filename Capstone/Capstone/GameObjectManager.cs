using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class GameObjectManager
    {
        List<GameObject> gameObjects;
        List<GameObject> gameObjectsDead;
        private static GameObjectManager instance;
        public static GameObjectManager Instance
        {
            get
            {
                instance = (instance == null) ? new GameObjectManager() : instance;

                return instance;
            }
        }
        private GameObjectManager()
        {
            gameObjects = new List<GameObject>();

            gameObjectsDead = new List<GameObject>();
        }
        public void AddGameObject(GameObject obj)
        {
            gameObjects.Add(obj);
        }
        public void RemoveGameObject(GameObject obj)
        {
            gameObjectsDead.Add(obj);
        }
        public void Update()
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.Update();
            }
            foreach (GameObject obj in gameObjectsDead)
            {
                gameObjects.Remove(obj);
            }
            gameObjectsDead.Clear(); 
        }
    }
}
