using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    abstract class Controller : GameObjectComponent, IGameObjectUpdatable
    {
        protected GameObject parent;

        public Controller(GameObject parent) : base(parent)
        {
            this.parent = parent;
        }

        public abstract void Update();


    }
}
