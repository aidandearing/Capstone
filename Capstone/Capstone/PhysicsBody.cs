using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Capstone
{
    class PhysicsBody
    {
        public enum BodyType { physics_rigidbody, physics_static, physics_kinematic, physics_trigger};

        public int flagBodyType = 0;
        public int flagLayer = 0;

        public GameObject gameObject;
        private Shape shape;

        List<Collision> lastCollisions;
        List<Collision.OnCollision> callbacks;

        void Update()
        {

        }
    }
}
