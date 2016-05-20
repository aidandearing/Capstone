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

        public enum CollisionType { start, stay, stop, none };

        public PhysicsBody BodyA;
        public PhysicsBody BodyB;
        public CollisionType type;

        void Collide(Collision collision)
        {
            type = CollisionType.none;
        }

        /// <summary>
        /// Evaluates whether the collision is occuring or not
        /// </summary>
        /// <returns>NOT IMPLEMENTED YET</returns>
        bool Evaluate()
        {
            bool test = BodyA.shape.Test(BodyB.shape);

            // If the test returns true, collision is occuring

            // If this type is none and test is true, collision is starting
            if (type == CollisionType.none && test)
                type = CollisionType.start;
            // If this type is start and test is true, collision is continuing
            if (type == CollisionType.start && test)
                type = CollisionType.stay;
            // If this type is start or stay and test is false, collision is ending
            if ((type == CollisionType.start || type == CollisionType.stay) && !test)
                type = CollisionType.stop;
            // If this type is stop and test is true, collision is starting, again
            if (type == CollisionType.stop && test)
                type = CollisionType.start;

            return test;
        }

        void Resolve()
        {

        }
    }
}
