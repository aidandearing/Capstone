using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class GameObject
    {
        public GameModel model;
        public Transform transform;

        public void Update()
        {

        }

        public void Draw()
        {
            // This will ultimately have some basic occlusion culling logic implemented
            model.Draw(transform);
        }
    }
}
