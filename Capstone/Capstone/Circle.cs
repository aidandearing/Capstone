using Microsoft.Xna.Framework;

namespace Capstone
{
    class Circle : Shape
    {
        public Circle(float radius)
        {
            points = new Vector3[1];
            points[0] = new Vector3(0, 0, radius);
        }

        public override ShapeIntersection[] Intersects(Shape shape)
        {
            return null;
        }
    }
}
