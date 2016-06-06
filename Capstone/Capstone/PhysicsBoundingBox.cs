using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class PhysicsBoundingBox<T>
    {
        public List<T> bodies;
        public AABB bounds;

        public PhysicsBoundingBox(AABB bounds)
        {
            this.bounds = bounds;
        }

        public void AddBody(T body)
        {
            bodies.Add(body);
        }

        public bool TestBody(PhysicsBody body)
        {
            return bounds.OverlapTest(body.shape);
        }
    }
}
