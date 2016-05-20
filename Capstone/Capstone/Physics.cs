using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class Physics
    {
        // Stores all collision callbacks in PhysicsBody key, list of callbacks form
        private Dictionary<PhysicsBody, List<Collision.OnCollision>> registeryCollisionCallbacks;
        // Stores all the active collisions in PhysicsBody key, list of collisions form
        private Dictionary<PhysicsBody, List<Collision>> registeryActiveCollisions;

        private List<PhysicsBody> activeBodies;
        private List<PhysicsBody> deadBodies;

        // Singleton
        private static Physics instance;
        public static Physics Instance()
        {
            instance = (instance == null) ? new Physics() : instance;
            return instance;
        }
        private Physics()
        {
            registeryCollisionCallbacks = new Dictionary<PhysicsBody, List<Collision.OnCollision>>();

            activeBodies = new List<PhysicsBody>();
            deadBodies = new List<PhysicsBody>();
        }
        // End of Singleton

        /// <summary>
        /// Adds a collision delegate to the physics bodies list of callbacks
        /// This enables something using the delegate to be alerted when the body is question collides with something else
        /// </summary>
        /// <param name="callback">The delegate to be added</param>
        /// <param name="body">The body to add the delegate to</param>
        public void RegisterCollisionCallback(Collision.OnCollision callback, PhysicsBody body)
        {
            // First check to see if the registry contains this key
            if (!registeryCollisionCallbacks.ContainsKey(body))
            {
                // If the registry does not contain the body, add the body, and its list of callbacks
                registeryCollisionCallbacks.Add(body, body.collisionCallbacks);
            }
            // Add the new callback to the list
            body.collisionCallbacks.Add(callback);
        }

        /// <summary>
        /// Removes a collision delegate from the physics body
        /// </summary>
        /// <param name="callback">The delegate to be removed</param>
        /// <param name="body">The body to remove the delegate from</param>
        public void UnregisterCollisionCallback(Collision.OnCollision callback, PhysicsBody body)
        {
            // First check to see if the registry contains this key
            if (registeryCollisionCallbacks.ContainsKey(body))
            {
                body.collisionCallbacks.Remove(callback);
            }
        }

        /// <summary>
        /// Given a body get all its collision callbacks
        /// </summary>
        /// <param name="body">The body to get callbacks from</param>
        /// <returns></returns>
        public List<Collision.OnCollision> GetCollisionCallbacks(PhysicsBody body)
        {
            // First check to see if the registry contains this key
            if (registeryCollisionCallbacks.ContainsKey(body))
            {
                // If it has this body, get its list
                return registeryCollisionCallbacks[body];
            }
            else
                return null;
        }

        public void AddPhysicsBody(PhysicsBody body)
        {
            activeBodies.Add(body);
        }

        public void RemovePhysicsBody(PhysicsBody body)
        {
            deadBodies.Add(body);
        }

        public void Step()
        {
            // I want to do some heavy broad phase logic here
            // But for now lets do something linear
            // Update all bodies
            foreach (PhysicsBody body in activeBodies)
            {
                body.Update();
            }

            // Remove all dead bodies
            foreach (PhysicsBody body in deadBodies)
            {
                activeBodies.Remove(body);

                // If they have registered callbacks remove them
                if (registeryCollisionCallbacks.ContainsKey(body))
                {
                    registeryCollisionCallbacks.Remove(body);
                }
            }
        }
    }
}
