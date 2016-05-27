using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Capstone
{
    class Physics : GameComponent
    {
        private Matrix worldToRender;
        private Matrix renderToWorld;

        public static Matrix WorldToRender(Matrix matrix)
        {
            return matrix * instance.worldToRender;
        }

        public static Matrix RenderToWorld(Matrix matrix)
        {
            return matrix * instance.renderToWorld;
        }

        #region Singleton
        // Singleton ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This region contains all the singleton methods and variables

        private static Physics instance;
        /// <summary>
        /// DO NOT USE THIS
        /// Unless you are stupid, or doing something sweet
        /// </summary>
        /// <param name="game">The Game instance running</param>
        /// <returns>The Physics instance running</returns>
        public static Physics Instance(Game game)
        {
            instance = (instance == null) ? new Physics(game) : instance;
            return instance;
        }
        private Physics(Game game) : base(game)
        {
            
        }
        // End of Singleton ////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Registries
        // Registries //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This region contains all the registry add and remove methods as well as the registry variables

        // Stores all collision callbacks in PhysicsBody key, list of callbacks form
        private Dictionary<PhysicsBody, List<Collision.OnCollision>> registery_CollisionCallbacks;
        // Stores all the active collisions in PhysicsBody key, list of collisions form
        private Dictionary<PhysicsBody, List<Collision>> registery_ActiveCollisions;

        /// <summary>
        /// Adds a collision delegate to the physics bodies list of callbacks
        /// This enables something using the delegate to be alerted when the body in question collides with something else
        /// </summary>
        /// <param name="callback">The delegate to be added</param>
        /// <param name="body">The body to add the delegate to</param>
        public static void RegisterCollisionCallback(Collision.OnCollision callback, PhysicsBody body)
        {
            // First check to see if the registry contains this key
            if (!instance.registery_CollisionCallbacks.ContainsKey(body))
            {
                // If the registry does not contain the body, add the body, and its list of callbacks
                instance.registery_CollisionCallbacks.Add(body, body.collisionCallbacks);
            }
            // Add the new callback to the list
            body.collisionCallbacks.Add(callback);
        }

        /// <summary>
        /// Removes a collision delegate from the physics body
        /// </summary>
        /// <param name="callback">The delegate to be removed</param>
        /// <param name="body">The body to remove the delegate from</param>
        public static void UnregisterCollisionCallback(Collision.OnCollision callback, PhysicsBody body)
        {
            // First check to see if the registry contains this key
            if (instance.registery_CollisionCallbacks.ContainsKey(body))
            {
                body.collisionCallbacks.Remove(callback);
            }
        }

        /// <summary>
        /// Given a body get all its collision callbacks
        /// </summary>
        /// <param name="body">The body to get callbacks from</param>
        /// <returns></returns>
        public static List<Collision.OnCollision> GetCollisionCallbacks(PhysicsBody body)
        {
            // First check to see if the registry contains this key
            if (instance.registery_CollisionCallbacks.ContainsKey(body))
            {
                // If it has this body, get its list
                return instance.registery_CollisionCallbacks[body];
            }
            else
                return null;
        }
        // End of Registries ////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Bodies
        // Bodies ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This region contains all the body methods as well as the body variables

        private List<PhysicsBody> bodies_All;
        private List<PhysicsBody> bodies_Active;
        private List<PhysicsBody> bodies_Dead;

        public static void AddPhysicsBody(PhysicsBody body)
        {
            instance.bodies_All.Add(body);
        }

        public static void RemovePhysicsBody(PhysicsBody body)
        {
            instance.bodies_Dead.Add(body);
        }
        // End of Bodies ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region GameComponent
        // GameComponent ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This region contains all the GameComponent overrides

        private Game game;

        /// <summary>
        /// Initialises the Physics class, this is what enables this class to be used statically
        /// </summary>
        public override void Initialize()
        {
            registery_CollisionCallbacks = new Dictionary<PhysicsBody, List<Collision.OnCollision>>();
            registery_ActiveCollisions = new Dictionary<PhysicsBody, List<Collision>>();

            bodies_All = new List<PhysicsBody>();
            bodies_Active = new List<PhysicsBody>();
            bodies_Dead = new List<PhysicsBody>();

            worldToRender = Matrix.CreateScale(200f);
            renderToWorld = Matrix.CreateScale(1 / 200.0f);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Remove all dead bodies
            foreach (PhysicsBody body in bodies_Dead)
            {
                bodies_All.Remove(body);
                bodies_Active.Remove(body);

                // If they have registered callbacks remove them
                if (registery_CollisionCallbacks.ContainsKey(body))
                {
                    registery_CollisionCallbacks.Remove(body);
                }
            }
        }
        // End of GameComponent /////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion
    }
}
