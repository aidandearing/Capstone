using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Capstone
{
    
    class FoodModifier
    {
        public enum Modifier { add, multiply, prepend, append, remove };
        public Modifier modifier;
        public FoodState.CutState cutState;
        public FoodState.TempState tempState;
        public FoodState.CookState cookState;
        public string value;

        public FoodModifier(FoodState.CutState cutState, FoodState.TempState tempState, FoodState.CookState cookState, Modifier modifier, string value)
        {
            this.cutState = cutState;
            this.tempState = tempState;
            this.cookState = cookState;
            this.value = value;
            this.modifier = modifier;
        }
        public string GetValue(string val)
        {
            switch (modifier)
            {
                case Modifier.add:
                    return val + value;
                case Modifier.multiply:
                    return val + value;
                case Modifier.prepend:
                    return value + val;
                case Modifier.append:
                    return val + value;
            }
            return val;
        }
        public int GetValue(int val)
        {
            switch (modifier)
            {
                case Modifier.add:
                    return int.Parse(value) + val;
                case Modifier.multiply:
                    return int.Parse(value) * val;
                case Modifier.prepend:
                    return int.Parse(value + val.ToString());
                case Modifier.append:
                    return int.Parse(val.ToString() + value);
            }
            return val;
        }
        public float GetValue(float val)
        {
            switch (modifier)
            {
                case Modifier.add:
                    return float.Parse(value) + val;
                case Modifier.multiply:
                    return float.Parse(value) * val;
                case Modifier.prepend:
                    return float.Parse(value + val.ToString());
                case Modifier.append:
                    return float.Parse(val.ToString() + value);
            }
            return val;
        }
        public List<string>GetValue(List<string> val)
        {
            switch (modifier)
            {
                case Modifier.add:
                    val.Add(value);
                    return val;
                case Modifier.remove:
                    val.Remove(value);
                    return val;
            }
            return val;
        }
    }
}
