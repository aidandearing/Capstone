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
        private static GameObjectManager instance;
        public static GameObjectManager Instance
        {
            get
            {
                instance = (instance == null) ? new GameObjectManager() : instance;

                return instance;
            }
        }
        public void AddGameObject(GameObject obj)
        {
            gameObjects.Add(obj);
        }
        public void RemoveGameObject(GameObject obj)
        {
            gameObjects.Remove(obj);
        }
        public void Update()
        {

        }
    }
}
