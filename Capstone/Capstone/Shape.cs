using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Capstone
{
    class Shape
    {
        public const int VERTICELIMIT = 16;
        protected Vector3[] points = new Vector3[VERTICELIMIT];

        public Shape()
        {
            
        }

        public Shape(Vector3[] points)
        {
            if (points.Length <= VERTICELIMIT)
            {
                this.points = points;
            }
            else
            {
                for (int i = 0; i < VERTICELIMIT; ++i)
                {
                    this.points[i] = points[i];
                }
            }
        }

        public virtual ShapeIntersection[] Intersects(Shape shape)
        {
            // SAT
            return null;
        }
    }
}
