using System;
using System.Collections.Generic;

namespace Definitions
{
	public class Defs
	{
        // TODO: Definir los tipos,subtype y wearin pos de los items
        public static Dictionary<string, List<string>> ItemTypes = new Dictionary<string, List<string>>
		{
			{
				"Weapon", new List<string>
				{
					"(Knight) Single Sword",
                    "(EX|Rogue) Crossbow",
                    "(Arch|Mage) Staff",
                    "(Titan) Bigsword",
                    "(Titan) Axe",
                    "(Arch|Mage) Short Staff (Wand)",
                    "(Healer) Bow",
                    "(EX|Rogue) Daggers",
                    "Mining (Hammer)",
                    "Gathering (Knife)",
                    "Charge (Energy Collector)",
                    "(Knight) Double Swords",
                    "(Healer) Scepter",
                    "(Sorcerer) Scythe",
                    "(Sorcerer) Fallarm",
                    "(Nightshadow) Soul"
                }
			},
			{
				"Armor", new List<string>
				{
					"helmet",
					"chest"
				}
			},
			{
                "Once (Book, Scroll)", new List<string>
                {
                }
            },
            {
                "Shot", new List<string>
                {
                }
            },
            {
                "Etc (Quest, Event, Upgrade)", new List<string>
                {
                }
            },
            {
                "Accesory", new List<string>
                {
                }
            },
            {
                "Potion", new List<string>
                {
                }
            }
        };
	}
}
