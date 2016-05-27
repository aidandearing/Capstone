using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Capstone
{
    class PhysicsBody : GameObjectComponent, IGameObjectUpdatable
    {
        public enum BodyType { physics_rigidbody, physics_static, physics_kinematic, physics_trigger };

        public int flagBodyType = 0;
        public int flagLayer = 0;

        public Shape shape;

        /// <summary>
        /// transform stores all the physics forces acting on the body in matrix form
        /// </summary>
        private Matrix transform;

        // This list is referenced in Physic's callback registery
        public List<Collision.OnCollision> collisionCallbacks;
        // This list is referenced in Physic's collision registery
        public List<Collision> collisions;

        public PhysicsBody(GameObject parent, Shape shape) : base(parent)
        {
            this.shape = shape;

            collisionCallbacks = new List<Collision.OnCollision>();
            collisions = new List<Collision>();

            Physics.AddPhysicsBody(this);
        }

        void IGameObjectUpdatable.Update()
        {
            // I need to construct the transform for this
            parent.transform.Transformation += transform;
        }

        public void RegisterCollisionCallback(Collision.OnCollision callback)
        {
            Physics.RegisterCollisionCallback(callback, this);
        }

        public void UnregisterCollisionCallback(Collision.OnCollision callback)
        {
            Physics.UnregisterCollisionCallback(callback, this);
        }

        public void Remove()
        {
            Physics.RemovePhysicsBody(this);
        }
    }
}
