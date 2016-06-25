using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Xml;

namespace Capstone
{
    class FoodTemplate
    {
        public enum Flags { CanBeCooked = 0x01, CanBeCut = 0x02, CanBeFrozen = 0x04 };
        public Flags foodFlags = 0;
        private string name;
        public string Name
        {
            get { return name; }
        }
        private string description;
        public string Description
        {
            get { return description; }
        }
        private float value;
        public float Value
        {
            get { return value; }
        }
        private float weight;
        public float Weight
        {
            get { return weight; }
        }
        private float size;
        public float Size
        {
            get { return size; }
        }
        private int stack;
        public int Stack
        {
            get { return stack; }
        }
        private int rarity;
        public int Rarity
        {
            get { return rarity; }
        }
        private List <string> categories;
        public List <string> Categories
        {
            get { return categories; }
        }
        private int decay;
        public int Decay
        {
            get { return decay; }
        }
        private Dictionary<float,string> decayNames;
        public Dictionary<float,string> DecayNames
        {
            get { return decayNames; }
        }
        private int foodMin;
        public int FoodMin
        {
            get { return foodMin; }
        }
        private int foodMax;
        public int FoodMax
        {
            get { return foodMax; }
        }
        private int nutritionMin;
        public int NutritionMin
        {
            get { return nutritionMin; }
        }
        private int nutritionMax;
        public int NutritionMax
        {
            get { return nutritionMax; }
        }
        private int poisonMin;
        public int PoisonMin
        {
            get { return poisonMin; }
        }
        private int poisonMax;
        public int PoisonMax
        {
            get { return poisonMax; }
        }
        private string modelName;
        public string ModelName
        {
            get { return modelName; }
        }
        FoodTemplate(XmlReader reader)
        {
            int depth = reader.Depth;
            categories = new List<string>();
            decayNames = new Dictionary<float, string>();
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "name":
                            if (reader.Read())
                                name = reader.Value;
                            break;

                        case "description":
                            if (reader.Read())
                                description = reader.Value;
                            break;

                        case "value":
                            if (reader.Read())
                                value = float.Parse(reader.Value);
                            break;

                        case "weight":
                            if (reader.Read())
                                weight = float.Parse(reader.Value);
                            break;

                        case "size":
                            if (reader.Read())
                                size = float.Parse(reader.Value);
                            break;

                        case "stack":
                            if (reader.Read())
                                stack = int.Parse(reader.Value);
                            break;

                        case "rarity":
                            if (reader.Read())
                                rarity = int.Parse(reader.Value);
                            break;

                        case "model":
                            if (reader.Read())
                                modelName = reader.Value;
                            break;

                        case "categories":
                            
                            while (reader.Read() && reader.Depth > depth)
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
                                    {
                                        case "category":
                                            if (reader.Read())
                                                categories.Add(reader.Value);
                                            break;
                                    }
                                }
                            }
                            break;

                        case "decay":
                            if (reader.Read())
                                decay = int.Parse(reader.Value);
                            break;

                        case "decayNames":
                            while (reader.Read() && reader.Depth > depth)
                            {
                                if (reader.IsStartElement())
                                {
                                    switch(reader.Name)
                                    {
                                        case "decay":
                                            float percent = float.Parse(reader["stage"]);
                                            if (reader.Read())
                                                decayNames.Add(percent, reader.Value);
                                            break;
                                    }
                                }
                            }
                            break;

                        case "food":
                            while (reader.Read() && reader.Depth > depth)
                            {
                                if (reader.IsStartElement())
                                {
                                    switch(reader.Name)
                                    {
                                        case "max":
                                            if (reader.Read())
                                                foodMax = int.Parse(reader.Value);
                                            break;

                                        case "min":
                                            if (reader.Read())
                                                foodMin = int.Parse(reader.Value);
                                            break;
                                    }
                                }
                            }
                            break;

                        case "nutrition":
                            while (reader.Read() && reader.Depth > depth)
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
                                    {
                                        case "max":
                                            if (reader.Read())
                                                nutritionMax = int.Parse(reader.Value);
                                            break;

                                        case "min":
                                            if (reader.Read())
                                                nutritionMin = int.Parse(reader.Value);
                                            break;
                                    }
                                }
                            }
                            break;

                        case "poison":
                            while (reader.Read() && reader.Depth > depth)
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
                                    {
                                        case "max":
                                            if (reader.Read())
                                                poisonMax = int.Parse(reader.Value);
                                            break;

                                        case "min":
                                            if (reader.Read())
                                                poisonMin = int.Parse(reader.Value);
                                            break;
                                    }
                                }
                            }
                            break;

                        case "flags":
                            while (reader.Read() && reader.Depth > depth)
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
                                    {
                                        case "canBeCooked":
                                            if (reader.Read())
                                                if (bool.Parse(reader.Value))
                                                    foodFlags = foodFlags | Flags.CanBeCooked;
                                            break;

                                        case "canBeCut":
                                            if (reader.Read())
                                                if (bool.Parse(reader.Value))
                                                    foodFlags = foodFlags | Flags.CanBeCut;
                                            break;

                                        case "canBeFrozen":
                                            if (reader.Read())
                                                if (bool.Parse(reader.Value))
                                                    foodFlags = foodFlags | Flags.CanBeFrozen;
                                            break;
                                    }
                                }
                            }
                            break;



                    }
                }
            }

        }
    }
}
