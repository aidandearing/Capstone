using Microsoft.Xna.Framework;

namespace Capstone
{
    class Camera
    {
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
            //projection = Matrix.CreateOrthographic()

            // isometric angle is 35.2º => for -14.1759f Y = 10 Z
            // I will be normalising this at some point in the future
            Vector3 position = new Vector3(0, -14.1759f, 10f);
            Vector3 lookAt = new Vector3(0, 0, 0);
            view = Matrix.CreateLookAt(position, lookAt, Vector3.Up);

            projection = Matrix.CreateOrthographic(800, 600, 0, 1000);
        }

        public Matrix view;
        public Matrix projection;
        public Transform transform;
    }
}
