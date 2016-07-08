using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Xml;

namespace Capstone
{
    class Food
    {
        public static Dictionary<string, Food> foods;
        public enum Flags { CanBeCooked = 0x01, CanBeCut = 0x02, CanBeFrozen = 0x04 };
        public Flags foodFlags = 0;
        public List<string> effects;
        private string name;
        public List<FoodModifier> nameModifiers = new List<FoodModifier>();
        public string Name(FoodState foodState)
        {
            string n = name;

            foreach (FoodModifier mod in nameModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    n = mod.GetValue(n);
                }
            }
            return n;
        }
        private string description;
        public List<FoodModifier> descriptionModifiers = new List<FoodModifier>();
        public string Description(FoodState foodState)
        {
            string d = description;

            foreach (FoodModifier mod in descriptionModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    d = mod.GetValue(d);
                }
            }
            return d;
        }
        private float value;
        public List<FoodModifier> valueModifiers = new List<FoodModifier>();
        public float Value(FoodState foodState)
        {
            float v = value;

            foreach (FoodModifier mod in valueModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    v = mod.GetValue(v);
                }
            }
            return v;
        }
        private float weight;
        public List<FoodModifier> weightModifiers = new List<FoodModifier>();
        public float Weight(FoodState foodState)
        {
            float w = weight;

            foreach (FoodModifier mod in weightModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    w = mod.GetValue(w);
                }
            }
            return w;
        }
        private float size;
        public List<FoodModifier> sizeModifiers = new List<FoodModifier>();
        public float Size(FoodState foodState)
        {
            float s = size;

            foreach (FoodModifier mod in sizeModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    s = mod.GetValue(s);
                }
            }
            return s;
        }
        private int stack;
        public List<FoodModifier> stackModifiers = new List<FoodModifier>();
        public int Stack(FoodState foodState)
        {
            int s = stack;

            foreach (FoodModifier mod in stackModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    s = mod.GetValue(s);
                }
            }
            return s;
        }
        private int rarity;
        public List<FoodModifier> rarityModifiers = new List<FoodModifier>();
        public int Rarity(FoodState foodState)
        {
            int r = rarity;

            foreach (FoodModifier mod in rarityModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    r = mod.GetValue(r);
                }
            }
            return r;
        }
        private List<string> categories;
        public List<FoodModifier> categoryModifiers = new List<FoodModifier>();
        public List<string> Categories(FoodState foodState)
        {
            List<string> c = categories;

            foreach (FoodModifier mod in categoryModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    c = mod.GetValue(c);
                }
            }
            return c;
        }
        private int decay;
        public List<FoodModifier> decayModifiers = new List<FoodModifier>();
        public int Decay(FoodState foodState)
        {
            int d = decay;

            foreach (FoodModifier mod in decayModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    d = mod.GetValue(d);
                }
            }
            return d;
        }
        private List<string> decayNames;
        public List<FoodModifier> decayNameModifiers = new List<FoodModifier>();
        public List<string> DecayNames(FoodState foodState)
        {
            List<string> d = decayNames;

            foreach (FoodModifier mod in decayNameModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    d = mod.GetValue(d);
                }
            }
            return d;
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
        private int foodAmount;
        public List<FoodModifier> foodModifiers = new List<FoodModifier>();
        public int FoodAmount(FoodState foodState)
        {
            float f = MathHelper.Lerp(foodMin, FoodMax, foodState.Decay() / Decay(foodState));

            foreach (FoodModifier mod in foodModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    f = mod.GetValue(f);
                }
            }
            return (int)f;
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
        private int nutritionAmount;
        public List<FoodModifier> nutritionModifiers = new List<FoodModifier>();
        public int NutritionAmount(FoodState foodState)
        {
            float n = MathHelper.Lerp(nutritionMin, nutritionMax, foodState.Decay() / Decay(foodState));

            foreach (FoodModifier mod in nutritionModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    n = mod.GetValue(n);
                }
            }
            return (int)n;
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
        private int poisonAmount;
        public List<FoodModifier> poisonModifiers = new List<FoodModifier>();
        public int PoisonAmount(FoodState foodState)
        {
            float p = MathHelper.Lerp(poisonMin, poisonMax, foodState.Decay() / Decay(foodState));

            foreach (FoodModifier mod in poisonModifiers)
            {
                if ((mod.cutState == foodState.cutState || mod.cutState == FoodState.CutState.idc) && (mod.tempState == foodState.tempState || mod.tempState == FoodState.TempState.idc) && (mod.cookState == foodState.cookState || mod.cookState == FoodState.CookState.idc))
                {
                    p = mod.GetValue(p);
                }
            }
            return (int)p; 
        }
            
        private string modelName;
        public string ModelName
        {
            get { return modelName; }
        }

        Food(XmlReader reader)
        {
            int depth = reader.Depth;
            int depth2;
            int depth3;
            FoodState.CutState cutState = new FoodState.CutState();
            FoodState.TempState tempState = new FoodState.TempState();
            FoodState.CookState cookState = new FoodState.CookState();
            FoodModifier.Modifier modType = new FoodModifier.Modifier();

            foods = new Dictionary<string, Food>();
            categories = new List<string>();
            decayNames = new List<string>();
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
                            depth = reader.Depth;
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
                            depth = reader.Depth;
                            while (reader.Read() && reader.Depth > depth)
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
                                    {
                                        case "decay":
                                            float percent = float.Parse(reader["stage"]);
                                            if (reader.Read())
                                                decayNames.Add(reader.Value);
                                            break;
                                    }
                                }
                            }
                            break;

                        case "food":
                            depth = reader.Depth;
                            while (reader.Read() && reader.Depth > depth)
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
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
                            depth = reader.Depth;
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
                            depth = reader.Depth;
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
                            depth = reader.Depth;
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

                        case "modifiers":
                            depth = reader.Depth;
                            while (reader.Read() && reader.Depth > depth)
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
                                    {
                                        case "modifier":
                                            Enum.TryParse<FoodState.CutState>(reader["cutType"], out cutState);
                                            Enum.TryParse<FoodState.TempState>(reader["tempType"], out tempState);
                                            Enum.TryParse<FoodState.CookState>(reader["cookType"], out cookState);

                                            depth2 = reader.Depth;

                                            while (reader.Read() && reader.Depth > depth2)
                                            {
                                                if (reader.IsStartElement())
                                                {
                                                    switch (reader.Name)
                                                    {
                                                        case "mod":
                                                            Enum.TryParse<FoodModifier.Modifier>(reader["type"], out modType);
                                                            string attribute = reader["attribute"].ToLower();
                                                            if (reader.Read())
                                                            {
                                                                string value = reader.Value;
                                                                FoodModifier mod = new FoodModifier(cutState, tempState, cookState, modType, value);

                                                                switch (attribute)
                                                                {
                                                                    case "name":
                                                                        nameModifiers.Add(mod);
                                                                        break;
                                                                    case "description":
                                                                        descriptionModifiers.Add(mod);
                                                                        break;
                                                                    case "value":
                                                                        valueModifiers.Add(mod);
                                                                        break;
                                                                    case "weight":
                                                                        weightModifiers.Add(mod);
                                                                        break;
                                                                    case "size":
                                                                        sizeModifiers.Add(mod);
                                                                        break;
                                                                    case "stack":
                                                                        stackModifiers.Add(mod);
                                                                        break;
                                                                    case "rarity":
                                                                        rarityModifiers.Add(mod);
                                                                        break;
                                                                    //modelname
                                                                    case "categories":
                                                                        categoryModifiers.Add(mod);
                                                                        break;
                                                                    case "decay":
                                                                        decayModifiers.Add(mod);
                                                                        break;
                                                                    case "decayNames":
                                                                        decayNameModifiers.Add(mod);
                                                                        break;
                                                                    case "food":
                                                                        foodModifiers.Add(mod);
                                                                        break;
                                                                    case "nutrition":
                                                                        nutritionModifiers.Add(mod);
                                                                        break;
                                                                    case "poison":
                                                                        poisonModifiers.Add(mod);
                                                                        break;
                                                                }
                                                            }
                                                            break;
                                                    }

                                                }
                                            }
                                            break;
                                    }
                                }
                                
                            }
                            break;

                        case "effects":
                            if (reader.Read())
                                effects.Add(reader.Value);
                            break;
                    }
                }
            }
        }
        public FoodState MakeFoodIntsance(string name)
        {
            return new FoodState(name);
        }
    }
}

