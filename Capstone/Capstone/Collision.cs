using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class Collision
    {
        public delegate void OnCollision(Collision collision);

        public enum CollisionType { start, stay, stop};

        public PhysicsBody BodyA;
        public PhysicsBody BodyB;

        void Collide(Collision collision)
        {

        }

        /// <summary>
        /// Evaluates whether the collision is occuring or not
        /// </summary>
        /// <returns>NOT IMPLEMENTED YET</returns>
        bool Evaluate()
        {
            return true;
        }

        void Resolve()
        {

        }
    }
}
