using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Definitions
{
	public class Defs
	{
		public static Dictionary<string, List<string>> ItemTypesNSubTypes = new Dictionary<string, List<string>>
		{
			{
				"Weapon", new List<string>
				{
					// Standards
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
					// Standards
					"Helmet",
					"Shirt",
					"Pants",
					"Gloves",
					"Boots",
					"Shield",
					"Backpack | Wings",
					"Complete Costume (SUIT)"
				}
			},
			{
				"Once (Varied)", new List<string>
				{
					// Standards
					"Teleporting (WARP)",
					"Production Manual",
					"Crafting Manual",
					"Box",
					"Potion Creation Manual",
					"Transformation Scroll",
					"Quest Scroll",
					"Changing Sutff (CASH)",
					"Summon",
					"Box or MonsterCombo (ETC)",
					"Attack Scroll (TARGET)",
					"Title",
					"Reward Package",
					"Jumping Potion",
					"Extend Chars Slot",
					"Server Trans",
					"Remote Express",
					"Jewel Pocket",
					"Chaos Jewel Pocket",
					"Cash Inventory",
					"Pet Stash",
					"GPS",
					"Holy Water",
					"Protect PvP"
				}
			},
			{
				"Shot", new List<string>
				{
					// Standards
					"Bullet Attack",
					"Bullet Mana",
					"Bullet Arrow"
				}
			},
			{
				"Etc (Quest, Event, Upgrade)", new List<string>
				{
					// Standards
					"Quest",
					"Event",
					"Skill Up",
					"Upgrade",
					"Material",
					"Gold (MONEY)",
					"Product",
					"Process",
					"Bloodseal (OPTION)",
					"Powder (SAMPLE)",
					"Event Item (TEXTURE)",
					"Castle Siege Concentration (MIX_TYPE1)",
					"Castle Siege Powder (MIX_TYPE2)",
					"Castle Siege Stone (MIX_TYPE3)",
					"APet Target (PET_AI)",
					"Quest Trigger",
					"Socket Jewel (JEWEL)",
					"Socket Upgrading (STABILIZER)",
					"Socket Creation (PROCESS_SCROLL)",
					"Mercenary (MONSTER_MERCENARY_CARD)",
					"Guild Mark",
					"Reformer (CHAOSJEWEL)",
					"Function (FUNCTIONS)",
					"RvR Jewel"
				}
			},
			{
				"Accesory", new List<string>
				{
					// Standards
					"Charm",
					"Magic Stone",
					"Light Stone",
					"Earing",
					"Ring",
					"Necklace",
					"Pet",
					"APet (ATTACK_PET)",
					"Artifact"
				}
			},
			{
				"Potion", new List<string>
				{
					// Standards
					"Antidote/Cure (STATE)",
					"HP Recover (HP)",
					"MP Recover (MP)",
					"HP & MP (DUAL)",
					"Statistic (STAT)",
					"Steroid (ETC)",
					"Mineral (UP)",
					"Tears",
					"Exp Crystal (CRYSTAL)",
					"NPC Scroll (NPC_PORTAL)",
					"HP Recovery Speed Potion (HP_SPEEDUP)",
					"MP Recovery Speed Potion (MP_SPEEDUP)",
					"APet HP Recover (PET_HP)",
					"APet Speed Up (PET_SPEEDUP)",
					"Totem",
					"APet MP Recover (PET_MP)"
				}
			}
		};

		public static string[] ItemWearingPositions =
		{
			// Standards
			"(-1) None",
			"(0) Helmet",
			"(1) Shirt",
			"(2) Weapon",
			"(3) Pants",
			"(4) Shield",
			"(5) Gloves",
			"(6) Boots",
			"(7) Accesory 1",
			"(8) Accesory 2",
			"(9) Accesory 3",
			"(10) Pet",
			"(11) Backpack | Wings"
		};

		public static Dictionary<string, List<string>> SyndicateTypesNGrades = new Dictionary<string, List<string>>
		{
			{
				"None", null
			},
			{
				"Kailux", new List<string>
				{
					// Standards
					"Squire",
					"Knight",
					"Gentor",
					"Honorise",
					"Barone",
					"Visconte",
					"Conte",
					"Marquise",
					"Duka",                     // NOTE: No points defined in source
					"Principe (6144 Principal)" // NOTE: No points defined in source
				}
			},
			{
				"Dilamun", new List<string>
				{
					// Standards
					"Neoptye (6145 Neopyte)",
					"Zelator",
					"Theoricus",
					"Philosophus",
					"Adeptus",
					"Magus",        // NOTE: No points defined in source
					"Ipsissimus"    // NOTE: No points defined in source
				}
			}
		};

		public static string[] ItemCastleTypes =
		{
			// Standards
			"Done",
			"All",
			"Merac",
			"Dratan"
		};

		public static string[] ItemClass =
		{
			// Standards
			"Titan",
			"Knight",
			"Helaer",
			"Mage",
			"Rogue",
			"Sorcerer",
			"Nightshadow",
			"Ex-Rogue",
			"Arch-Mage",
			"Pet",
			"APet"
		};

		public static string[] ItemFlag =
		{
			// Standards
			"Count",
			"Drop",
			"Upgrade",
			"Exchange",
			"Trade (Sell In NPC)",
			"Not Delete",
			"Made",
			"Mix",
			"Cash",
			"Lord",
			"No Stash",
			"Change",
			"Composite",
			"Duplication",
			"Lent",
			"Rare",
			"ABS",
			"Not Reform",
			"Zone Move Delete",
			"Origin (Purple Seals)",
			"Trigger",
			"Raid Special",
			"Quest",
			"Box (LuckyDraw Box)",
			"Not Trade Agent",
			"Durability",
			"Costume 2",
			"Socket",
			"Seller",
			"Castillan",
			"Lets Party",
			"Non RvR",
			"Quest Give",
			"Toggle",
			"Compose",
			"Not Single",
			"Invisible Custom",
			// NicolasG Custom
			"Money Ticket",
			"Party Teleport"
		};
	}
}
