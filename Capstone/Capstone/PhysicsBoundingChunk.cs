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
        private enum QUAD { All = 0, One = 1, Two = 6, Three = 11, Four = 16 };

        private AABB[] bounds;
        private Transform transform;
        private Dictionary<AABB, List<PhysicsBody>> statics;

        public PhysicsBoundingChunk(Transform transform)
        {
            this.transform = transform;

            statics = new Dictionary<AABB, List<PhysicsBody>>();

            // 21 because:
            // ┌──────┐
            // |      |
            // |      |
            // └──────┘
            // +
            // ┌──┐┌──┐
            // └──┘└──┘
            // ┌──┐┌──┐
            // └──┘└──┘
            // +
            // ┌─┐┌─┐┌─┐┌─┐
            // └─┘└─┘└─┘└─┘
            // ┌─┐┌─┐┌─┐┌─┐
            // └─┘└─┘└─┘└─┘
            // ┌─┐┌─┐┌─┐┌─┐
            // └─┘└─┘└─┘└─┘
            // ┌─┐┌─┐┌─┐┌─┐
            // └─┘└─┘└─┘└─┘ 
            // = 21
            bounds = new AABB[21];

            // Full bounding box, largest pass
            bounds[(int)QUAD.All] = new AABB(transform, 8, 8);

            // First quad
            bounds[(int)QUAD.One] = new AABB(new Transform(transform.Transformation.Translation + new Vector3(2, 0, -2), transform.Transformation.Scale, transform.Transformation.Rotation), 4, 4);

            // First quads four subdivisions
            bounds[(int)QUAD.One + 1] = new AABB(new Transform(bounds[(int)QUAD.One].transform.Transformation.Translation + new Vector3(1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.One + 2] = new AABB(new Transform(bounds[(int)QUAD.One].transform.Transformation.Translation + new Vector3(-1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.One + 3] = new AABB(new Transform(bounds[(int)QUAD.One].transform.Transformation.Translation + new Vector3(-1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.One + 4] = new AABB(new Transform(bounds[(int)QUAD.One].transform.Transformation.Translation + new Vector3(1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);

            // Second quad
            bounds[(int)QUAD.Two] = new AABB(new Transform(transform.Transformation.Translation + new Vector3(-2, 0, -2), transform.Transformation.Scale, transform.Transformation.Rotation), 4, 4);

            // Second quads four subdivisions
            bounds[(int)QUAD.Two + 1] = new AABB(new Transform(bounds[(int)QUAD.Two].transform.Transformation.Translation + new Vector3(1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.Two + 2] = new AABB(new Transform(bounds[(int)QUAD.Two].transform.Transformation.Translation + new Vector3(-1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.Two + 3] = new AABB(new Transform(bounds[(int)QUAD.Two].transform.Transformation.Translation + new Vector3(-1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.Two + 4] = new AABB(new Transform(bounds[(int)QUAD.Two].transform.Transformation.Translation + new Vector3(1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            
            // Third quad
            bounds[(int)QUAD.Three] = new AABB(new Transform(transform.Transformation.Translation + new Vector3(-2, 0, 2), transform.Transformation.Scale, transform.Transformation.Rotation), 4, 4);

            // Third quads four subdivisions
            bounds[(int)QUAD.Three + 1] = new AABB(new Transform(bounds[(int)QUAD.Three].transform.Transformation.Translation + new Vector3(1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.Three + 2] = new AABB(new Transform(bounds[(int)QUAD.Three].transform.Transformation.Translation + new Vector3(-1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.Three + 3] = new AABB(new Transform(bounds[(int)QUAD.Three].transform.Transformation.Translation + new Vector3(-1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.Three + 4] = new AABB(new Transform(bounds[(int)QUAD.Three].transform.Transformation.Translation + new Vector3(1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);

            // Fourth quad
            bounds[(int)QUAD.Four] = new AABB(new Transform(transform.Transformation.Translation + new Vector3(2, 0, 2), transform.Transformation.Scale, transform.Transformation.Rotation), 4, 4);

            // Fourth quads four subdivisions
            bounds[(int)QUAD.Four + 1] = new AABB(new Transform(bounds[(int)QUAD.Four].transform.Transformation.Translation + new Vector3(1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.Four + 2] = new AABB(new Transform(bounds[(int)QUAD.Four].transform.Transformation.Translation + new Vector3(-1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.Four + 3] = new AABB(new Transform(bounds[(int)QUAD.Four].transform.Transformation.Translation + new Vector3(-1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[(int)QUAD.Four + 4] = new AABB(new Transform(bounds[(int)QUAD.Four].transform.Transformation.Translation + new Vector3(1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);

            for (short i = 0; i < 21; ++i)
            {
                statics.Add(bounds[i], new List<PhysicsBody>());
            }
        }

        public bool BoundsTest(PhysicsBody body)
        {
            if (!bounds[(int)QUAD.All].OverlapTest(body.shape))
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
                    statics[bounds[(int)QUAD.All]].Add(body);

                    // Definitely not the fastest way to do this, but the way it is being done, for now.
                    // TODO Add smarter algorithm for checking size of body, skipping adding bodies to smaller bounds lists if body is bigger than all smaller bounds.
                    for (short i = 1; i < 21; ++i)
                    {
                        if (bounds[i].OverlapTest(body.shape))
                            statics[bounds[i]].Add(body);
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
            if (BoundsTest(body))
            {
                if (bounds[(int)QUAD.One].OverlapTest(body.shape))
                {
                    for (short i = 1; i < 5; ++i)
                    {
                        if (bounds[(int)QUAD.One + i].OverlapTest(body.shape))
                        {
                            bodies.AddRange(statics[bounds[(int)QUAD.One + i]]);
                        }
                    }
                }

                if (bounds[(int)QUAD.Two].OverlapTest(body.shape))
                {
                    for (short i = 1; i < 5; ++i)
                    {
                        if (bounds[(int)QUAD.Two + i].OverlapTest(body.shape))
                        {
                            bodies.AddRange(statics[bounds[(int)QUAD.Two + i]]);
                        }
                    }
                }

                if (bounds[(int)QUAD.Three].OverlapTest(body.shape))
                {
                    for (short i = 1; i < 5; ++i)
                    {
                        if (bounds[(int)QUAD.Three + i].OverlapTest(body.shape))
                        {
                            bodies.AddRange(statics[bounds[(int)QUAD.Three + i]]);
                        }
                    }
                }

                if (bounds[(int)QUAD.Four].OverlapTest(body.shape))
                {
                    for (short i = 1; i < 5; ++i)
                    {
                        if (bounds[(int)QUAD.Four + i].OverlapTest(body.shape))
                        {
                            bodies.AddRange(statics[bounds[(int)QUAD.Four + i]]);
                        }
                    }
                }
            }

            return bodies;
        }
    }
}
