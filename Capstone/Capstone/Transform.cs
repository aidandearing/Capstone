using Microsoft.Xna.Framework;

namespace Capstone
{
    class Transform
    {
        private Matrix transformation;

        public Matrix Transformation
        {
            get
            {
                return transformation;
            }
            set
            {
                transformation = value;
            }
        }

        public Vector3 Position
        {
            get
            {
                return transformation.Translation;
            }
            set
            {
                transformation.Translation = value;
            }
        }

        public Quaternion Rotation
        {
            get
            {
                return transformation.Rotation;
            }
        }
        
        public Vector3 Forward
        {
            get
            {
                return transformation.Forward;
            }
            set
            {
                transformation.Forward = value;
            }
        }

        public Vector3 Left
        {
            get
            {
                return transformation.Left;
            }
            set
            {
                transformation.Left = value;
            }
        }

        public Transform()
        {
            transformation = Matrix.Identity;
            Forward = transformation.Forward;
            Left = transformation.Left;
        }

        public Vector3 WorldToLocal(Vector3 vector)
        {
            return transformation.Translation - vector;
        }

        public Vector3 LocalToWorld(Vector3 vector)
        {
            return transformation.Translation + vector;
        }

        public void Translate(Vector3 vector)
        {
            // Maybe?
            transformation.Translation += vector;
        }

        public void Rotate(float angle)
        {
            // Ahk
        }
    }
}
