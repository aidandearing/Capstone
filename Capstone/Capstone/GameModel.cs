using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Capstone
{
    class GameModel
    {
        private static Dictionary<string, Model> models = new Dictionary<string, Model>();

        private Model model;

        public GameModel(Model model)
        {
            this.model = model;
        }

        public void Draw(Transform transform)
        {
            // It needs the transform matrix DONE
            // It needs the camera view matrix
            // It needs the projection matrix
            model.Draw(transform.Transformation, Camera.Instance.view, Camera.Instance.projection);
        }

        public static GameModel MakeGameModel(string name)
        {
            // If the model isn't already loaded (it's key isn't found in the dictionary)
            if (!models.ContainsKey(name))
            {
                // Needs to try to get the model at that name in the models path & load it
                Model model = ContentHelper.Content.Load<Model>("Assets/Models/" + name);
                // add the model into the dictionary
                models.Add(name, model);
            }
            // Pass the model at that key in the dictionary
            return new GameModel(models[name]);
        }
    }
}
