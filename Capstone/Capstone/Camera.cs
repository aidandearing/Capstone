using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public Matrix view;
        public Matrix projection;

        public void Update()
        {

        }
    }
}
