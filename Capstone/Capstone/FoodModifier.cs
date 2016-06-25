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
        public enum ModType { None, Sliced, Blended, Pasted, Warmed, Cooled, Frozen, Grilled, boiled, Fried, Cooked, Baked, Burnt };
        public ModType type = ModType.None;
        FoodModifier(XmlReader reader)
        {
            int depth = reader.Depth;

            while (reader.Read() && reader.Depth > depth)
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        /*case "modifier":
                            string modType = reader["type"];
                            if (modType == "None")
                                type = type | ModType.None;*/

                    }
                }
            }
        }
    }
}
