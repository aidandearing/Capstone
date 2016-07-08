using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class FoodState
    {
        public enum CutState { idc, none, sliced, pasted, blended };
        public enum TempState { idc, frozen, cooled, roomtemp, warmed };
        public enum CookState { idc, none, grilled, boiled, fried, cooked, burnt };

        public CutState cutState;
        public TempState tempState;
        public CookState cookState;
        public string name;

        public FoodState(string name)
        {
            this.name = name;
        }

        public string Name()
        {
            return Food.foods[name].Name(this);
        }

        public string Description()
        {
            return Food.foods[name].Description(this);
        }

        public float Value()
        {
            return Food.foods[name].Value(this);
        }

        public float Weight()
        {
            return Food.foods[name].Weight(this);
        }

        public float Size()
        {
            return Food.foods[name].Size(this);
        }

        public int Stack()
        {
            return Food.foods[name].Stack(this);
        }

        public int Rarity()
        {
            return Food.foods[name].Rarity(this);
        }

        public List<string> Categories()
        {
            return Food.foods[name].Categories(this);
        }

        public int Decay()
        {
            return Food.foods[name].Decay(this);
        }

        public List<string> DecayNames()
        {
            return Food.foods[name].DecayNames(this);
        }
        public int FoodAmount()
        {
            return Food.foods[name].FoodAmount(this);
        }
        public int NutritionAmount()
        {
            return Food.foods[name].NutritionAmount(this);
        }
        public int PoisonAmount()
        {
            return Food.foods[name].PoisonAmount(this);
        }


    }
}
