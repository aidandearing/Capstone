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
    /// Every PhysicsBoundingChunk contains 16 PhysicsBoundingBoxes
    /// </summary>
    class PhysicsBoundingChunk
    {
        private AABB[] bounds;
        private Transform transform;

        public PhysicsBoundingChunk(Transform transform)
        {
            this.transform = transform;

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
            bounds[0] = new AABB(transform, 8, 8);

            // First quad
            bounds[1] = new AABB(new Transform(transform.Transformation.Translation + new Vector3(2, 0, -2), transform.Transformation.Scale, transform.Transformation.Rotation), 4, 4);

            // First quads four subdivisions
            bounds[2] = new AABB(new Transform(bounds[1].transform.Transformation.Translation + new Vector3(1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[3] = new AABB(new Transform(bounds[1].transform.Transformation.Translation + new Vector3(-1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[4] = new AABB(new Transform(bounds[1].transform.Transformation.Translation + new Vector3(-1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[5] = new AABB(new Transform(bounds[1].transform.Transformation.Translation + new Vector3(1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);

            // Second quad
            bounds[6] = new AABB(new Transform(transform.Transformation.Translation + new Vector3(-2, 0, -2), transform.Transformation.Scale, transform.Transformation.Rotation), 4, 4);

            // Second quads four subdivisions
            bounds[7] = new AABB(new Transform(bounds[6].transform.Transformation.Translation + new Vector3(1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[8] = new AABB(new Transform(bounds[6].transform.Transformation.Translation + new Vector3(-1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[9] = new AABB(new Transform(bounds[6].transform.Transformation.Translation + new Vector3(-1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[10] = new AABB(new Transform(bounds[6].transform.Transformation.Translation + new Vector3(1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            
            // Third quad
            bounds[11] = new AABB(new Transform(transform.Transformation.Translation + new Vector3(-2, 0, 2), transform.Transformation.Scale, transform.Transformation.Rotation), 4, 4);

            // Third quads four subdivisions
            bounds[12] = new AABB(new Transform(bounds[11].transform.Transformation.Translation + new Vector3(1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[13] = new AABB(new Transform(bounds[11].transform.Transformation.Translation + new Vector3(-1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[14] = new AABB(new Transform(bounds[11].transform.Transformation.Translation + new Vector3(-1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[15] = new AABB(new Transform(bounds[11].transform.Transformation.Translation + new Vector3(1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);

            // Fourth quad
            bounds[16] = new AABB(new Transform(transform.Transformation.Translation + new Vector3(2, 0, 2), transform.Transformation.Scale, transform.Transformation.Rotation), 4, 4);

            // Fourth quads four subdivisions
            bounds[17] = new AABB(new Transform(bounds[16].transform.Transformation.Translation + new Vector3(1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[18] = new AABB(new Transform(bounds[16].transform.Transformation.Translation + new Vector3(-1, 0, -1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[19] = new AABB(new Transform(bounds[16].transform.Transformation.Translation + new Vector3(-1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
            bounds[20] = new AABB(new Transform(bounds[16].transform.Transformation.Translation + new Vector3(1, 0, 1), transform.Transformation.Scale, transform.Transformation.Rotation), 2, 2);
        }
    }
}
