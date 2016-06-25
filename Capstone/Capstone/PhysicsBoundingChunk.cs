using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Capstone
{
    /// <summary>
    /// Contains an array of Bounding Boxes that partition the worldspace in order to narrow the total number of collision checks any one non-static body must check against
    /// Follows some basic rules:
    /// Every PhysicsBoundingChunk is 8x8 physics units
    /// </summary>
    class PhysicsBoundingChunk
    {
        private AABB[] bounds;
        private Transform transform;
        private Dictionary<AABB, List<PhysicsBody>> statics;
        private Dictionary<int, int> indexToOrder;
        private Dictionary<int, List<AABB>> orderToIndex;
        private int sum;
        private int[] bound_dim;

        public PhysicsBoundingChunk(Transform transform)
        {
            this.transform = transform;

            statics = new Dictionary<AABB, List<PhysicsBody>>();
            indexToOrder = new Dictionary<int, int>();
            orderToIndex = new Dictionary<int, List<AABB>>();

            // Since it is dynamic (or at least not magic valued) it is the sum of all orders
            sum = ((int)Math.Pow(4, Properties.Physics.Default.BoundingBox_order) - 1) / (4 - 1);
            bounds = new AABB[sum];

            bound_dim = new int[Properties.Physics.Default.BoundingBox_order];
            for (int i = Properties.Physics.Default.BoundingBox_order; i > 0; i--)
            {
                bound_dim[Properties.Physics.Default.BoundingBox_order - i] = (int)Math.Pow(2, i);
            }

            int index = 0;
            for (int i = 0; i < Properties.Physics.Default.BoundingBox_order; ++i)
            {
                List<AABB> orderList = new List<AABB>();
                orderToIndex.Add(i, orderList);

                int numberAtOrder = (int)Math.Pow(4, i);
                int width = (int)Math.Pow(2, i);

                for (int j = 0; j < numberAtOrder; ++j)
                {
                    indexToOrder.Add(index, i);

                    Vector3 pos = (new Vector3(j % width, 0, (int)(j / width)) - new Vector3((numberAtOrder - 1) / width, 0, (numberAtOrder - 1) / width) / 2) * bound_dim[i];

                    Transform trans = new Transform(transform.Transformation.Translation + pos, transform.Transformation.Scale, transform.Transformation.Rotation);
                    bounds[index] = new AABB(trans, bound_dim[i], bound_dim[i]);
                    statics.Add(bounds[index], new List<PhysicsBody>());

                    orderList.Add(bounds[index]);
                    index++;
                }
            }
        }

        public bool BoundsTest(PhysicsBody body)
        {
            if (!bounds[0].OverlapTest(body.shape))
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to add a body to the bounding chunk, the criteria for failure are:
        /// The body is not static
        /// The body is not overlapping the bounds
        /// </summary>
        /// <param name="body">The body to add</param>
        /// <returns>True on success, False on failure</returns>
        public bool AddBody(PhysicsBody body)
        {
            if (body.flagBodyType.HasFlag(PhysicsBody.BodyType.physics_static))
            {
                if (BoundsTest(body))
                {
                    //statics[bounds[0]].Add(body);

                    // Definitely not the fastest way to do this, but the way it is being done, for now.
                    // TODO Add smarter algorithm for checking size of body, skipping adding bodies to smaller bounds lists if body is bigger than all smaller bounds.
                    //for (short i = 1; i < sum; ++i)
                    //{
                    //    if (bounds[i].OverlapTest(body.shape))
                    //        statics[bounds[i]].Add(body);
                    //}

                    // This is still slower than it can be. There are better ways of doing this.
                    // Go through the depths
                    for (int depth = 0; depth < Properties.Physics.Default.BoundingBox_order; ++depth)
                    {
                        // If the body is bigger than the current depth's bounds check it against the current depth
                        if (body.shape.GetBoundingBox().Diagonal() >= orderToIndex[depth][0].Diagonal())
                        {
                            // Foreach bound at the current depth
                            foreach(AABB bound in orderToIndex[depth])
                            {
                                // Check if the object overlaps and add it if it does
                                if (bound.OverlapTest(body.shape))
                                    statics[bound].Add(body);
                            }
                        }
                        // If the body is not larger than the current bounds and we are at the end of the depths
                        else if (depth >= Properties.Physics.Default.BoundingBox_order)
                        {
                            // Go through each bound at this depth (the final depth)
                            foreach(AABB bound in orderToIndex[depth])
                            {
                                // Check if the object overlaps and add it if it does
                                if (bound.OverlapTest(body.shape))
                                    statics[bound].Add(body);
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Given a body this method returns all bodies around that body in this bounding chunk
        /// </summary>
        /// <param name="body">The body to get neighbours of</param>
        /// <returns>Either a list of bodies, if the body is within this bounding chunk, or an empty list, if it is not</returns>
        public List<PhysicsBody> GetNearbyBodies(PhysicsBody body)
        {
            List<PhysicsBody> bodies = new List<PhysicsBody>();

            // TODO Once a better AddBody() system is in place this can change to a faster format
            // Instead of having to check the smallest bounds, it should be able to backout if the body is too big, and opt for assuming it wants to know about the smaller bounds list of bodies.
            //if (BoundsTest(body))
            //{
            //    if (bounds[(int)QUAD.One].OverlapTest(body.shape))
            //    {
            //        for (short i = 1; i < 5; ++i)
            //        {
            //            if (bounds[(int)QUAD.One + i].OverlapTest(body.shape))
            //            {
            //                bodies.AddRange(statics[bounds[(int)QUAD.One + i]]);
            //            }
            //        }
            //    }

            //    if (bounds[(int)QUAD.Two].OverlapTest(body.shape))
            //    {
            //        for (short i = 1; i < 5; ++i)
            //        {
            //            if (bounds[(int)QUAD.Two + i].OverlapTest(body.shape))
            //            {
            //                bodies.AddRange(statics[bounds[(int)QUAD.Two + i]]);
            //            }
            //        }
            //    }

            //    if (bounds[(int)QUAD.Three].OverlapTest(body.shape))
            //    {
            //        for (short i = 1; i < 5; ++i)
            //        {
            //            if (bounds[(int)QUAD.Three + i].OverlapTest(body.shape))
            //            {
            //                bodies.AddRange(statics[bounds[(int)QUAD.Three + i]]);
            //            }
            //        }
            //    }

            //    if (bounds[(int)QUAD.Four].OverlapTest(body.shape))
            //    {
            //        for (short i = 1; i < 5; ++i)
            //        {
            //            if (bounds[(int)QUAD.Four + i].OverlapTest(body.shape))
            //            {
            //                bodies.AddRange(statics[bounds[(int)QUAD.Four + i]]);
            //            }
            //        }
            //    }
            //}

            return bodies;
        }
    }
}
