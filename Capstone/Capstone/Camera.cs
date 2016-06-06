﻿using Microsoft.Xna.Framework;
using System;

namespace Capstone
{
    class Camera : GameComponent
    {
        private static Camera instance;
        public static Camera Instance(Game game)
        {
            instance = (instance == null) ? new Camera(game) : instance;
            return instance;
        }
        private Camera(Game game) : base(game) { }

        private Matrix view;
        public static Matrix View
        {
            get
            {
                return instance.view;
            }
        }
        private Matrix projection;
        public static Matrix Projection
        {
            get
            {
                return instance.projection;
            }
        }
        private Transform transform;
        public static Transform Transformation
        {
            get
            {
                return instance.transform;
            }
        }

        public override void Initialize()
        {
            // Isometric stuff
            // Making the camera view matrix rotated properly for the 45 degree arctan(1/sqrt(2)) stuffs that is necessary to create the appearance of 120 degrees between any 2 axis that is necessary for isometric
            Vector3 position = new Vector3((float)Math.Cos(Math.PI / 4.0f), (float)Math.Atan(1.0f / Math.Sqrt(2.0f)), (float)Math.Sin(Math.PI / 4.0f));
            Vector3 lookAt = new Vector3(0, 0, 0);
            view = Matrix.CreateLookAt(position, lookAt, Vector3.Up);

            // Standard orthographic projection
            projection = Matrix.CreateOrthographic(GraphicsHelper.screen.Width, GraphicsHelper.screen.Height, -1000, 1000);

            transform = new Transform();

            base.Initialize();
        }
    }
}
