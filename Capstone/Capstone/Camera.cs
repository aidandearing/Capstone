using Microsoft.Xna.Framework;
using System;

namespace Capstone
{
    class Camera
    {
        private static float helper_IsometricValue = (float)Math.Atan(1.0f / Math.Sqrt(2.0f));

        private static Camera instance;
        public static Camera Instance
        {
            get
            {
                instance = (instance == null) ? new Camera() : instance;

                return instance;
            }
        }
        private Camera()
        {
            Vector3 position = new Vector3(10, 10 + helper_IsometricValue, 10);
            Vector3 lookAt = new Vector3(0, 0, 0);
            view = Matrix.CreateLookAt(position, lookAt, Vector3.Up);

            projection = Matrix.CreateOrthographic(GraphicsHelper.screen.Width, GraphicsHelper.screen.Height, -1000, 1000);
        }

        public Matrix view;
        public Matrix projection;
        public Transform transform;
    }
}
