using Microsoft.Xna.Framework;

namespace Capstone
{
    class AABB : Shape
    {
        public AABB(float width, float height)
        {
            float halfwidth = width / 2;
            float halfheight = height / 2;

            points = new Vector3[4];
            points[0] = new Vector3(-halfwidth, 0, -halfheight);
            points[1] = new Vector3(-halfwidth, 0, halfheight);
            points[2] = new Vector3(halfwidth, 0, halfheight);
            points[3] = new Vector3(halfwidth, 0, -halfheight);
        }
    }
}
