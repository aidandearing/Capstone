using Microsoft.Xna.Framework;

namespace Capstone
{
    class Circle : Shape
    {
        public Circle(Transform transform, float radius) : base(transform)
        {
            points = new Vector3[1];
            points[0] = new Vector3(0, 0, radius);
        }

        public override ShapeIntersection[] Intersects(Shape shape)
        {
            // Circle Intersect logic

            return null;
        }

        public override bool Test(Shape shape)
        {
            // Circle Intersect logic
            if (shape is Circle)
            {
                // Circle intersect Circle
                Vector3 delta = shape.transform.Position - transform.Position;

                // Check the Circle against the other shape as a circle
                if (delta.Length() <= Radius() + ((Circle)shape).Radius())
                {
                    return true;
                }
            }
            else if (shape is AABB)
            {
                // Circle intersect AABB
                Vector3 delta = shape.transform.Position - transform.Position;

                // Check the Circle against the bounding circle of the AABB
                if (delta.Length() <= Radius() + ((AABB)shape).Diagonal())
                {
                    // Now find out if the point on the circles edge along the normal towards the AABB is within the AABB
                    delta.Normalize();
                    delta *= points[0].Z;
                    return ((AABB)shape).Intersects(delta);
                }

                return false;
            }
            else
            {
                // Circle intersects poly
            }

            return false;
        }

        public override bool Intersects(Vector3 point)
        {
            Vector3 delta = point - transform.Position;

            if (delta.Length() <= Radius())
            {
                return true;
            }

            return false;
        }

        public float Radius()
        {
            return points[0].Z;
        }
    }
}
