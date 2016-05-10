using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public void Draw()
        {
            
        }

        public static GameModel GetModel(string name)
        {
            // If the model isn't already loaded (it's key isn't found in the dictionary)
                // Needs to try to get the model at that name in the models path
                // If it fails return a null
                // If it succeeds load the model into the dictionary
            // Pass the model at that key in the dictionary
            return new GameModel(models[name]);
        }
    }
}
