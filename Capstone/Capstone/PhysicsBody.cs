using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Capstone
{
    class PhysicsBody
    {
        public enum BodyType { physics_rigidbody, physics_static, physics_kinematic, physics_trigger };

        public int flagBodyType = 0;
        public int flagLayer = 0;

        public GameObject gameObject;
        public Shape shape;

        // This list is referenced in Physic's callback registery
        public List<Collision.OnCollision> collisionCallbacks;
        // This list is referenced in Physic's collision registery
        public List<Collision> collisions;

        public PhysicsBody(GameObject parent, Shape shape)
        {
            gameObject = parent;
            this.shape = shape;

            collisionCallbacks = new List<Collision.OnCollision>();
            collisions = new List<Collision>();

            Physics.Instance().AddPhysicsBody(this);
        }

        public void Update()
        {

        }

        public void RegisterCollisionCallback(Collision.OnCollision callback)
        {
            Physics.Instance().RegisterCollisionCallback(callback, this);
        }

        public void UnregisterCollisionCallback(Collision.OnCollision callback)
        {
            Physics.Instance().UnregisterCollisionCallback(callback, this);
        }

        public void Remove()
        {
            Physics.Instance().RemovePhysicsBody(this);
        }
    }
}
