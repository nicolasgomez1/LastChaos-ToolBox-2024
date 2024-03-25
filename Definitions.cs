using System.Collections.Generic;

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
					"Reformer",
					"Chaos Jewel",
					"Functions",
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
					"Duka",                     // NOTE: probably not used
					"Principe (6144 Principal)" // NOTE: probably not used
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
					"Magus",        // NOTE: probably not used
					"Ipsissimus"    // NOTE: probably not used
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
			"APet",
			"Unknown"	// NOTE: Some apet items have 2048, are too much items to be a error, but flag only goest up to APET, i'm not sure of that.
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

		public static string[] APetTypes =
		{
			// Standards
			"None",
			"Human",
			"Beast",
			"Demon"
		};

		public static string[] JewelCompositePosition =
		{
			// Standards
			"Jewel Composite Weapon",
			"Jewel Composite Helmet",
			"Jewel Composite Armor",
			"Jewel Composite Pants",
			"Jewel Composite Gloves",
			"Jewel Composite Boots",
			"Jewel Composite Shield",
			"Jewel Composite Backpack | Wings",
			"Jewel Composite Accesory",
			"Jewel Composite All"
		};

		public static string[] FortuneItemProbTypes =
		{
			// Standards
			"Prob",
			"Random"
		};

		public static string[] OptionTypes =
		{
			// Standards
			"OPTION_STR_UP",
			"OPTION_DEX_UP",
			"OPTION_INT_UP",
			"OPTION_CON_UP",
			"OPTION_HP_UP",
			"OPTION_MP_UP",
			"OPTION_DAMAGE_UP",
			"OPTION_MELEE_DAMAGE_UP",
			"OPTION_RANGE_DAMAGE_UP",
			"OPTION_MELEE_HIT_UP",
			"OPTION_RANGE_HIT_UP",
			"OPTION_DEFENSE_UP",
			"OPTION_MELEE_DEFENSE_UP",
			"OPTION_RANGE_DEFENSE_UP",
			"OPTION_MELEE_AVOID_UP",
			"OPTION_RANGE_AVOID_UP",
			"OPTION_MAGIC_UP",
			"OPTION_MAGIC_HIT_UP",
			"OPTION_RESIST_UP",
			"OPTION_RESIST_AVOID_UP",
			"OPTION_ALL_DAMAGE_UP",
			"OPTION_ALL_HIT_UP",
			"OPTION_ALL_DEFENSE_UP",
			"OPTION_ALL_AVOID_UP",
			"OPTION_NOT_USED_24",
			"OPTION_NOT_USED_25",
			"OPTION_ATTR_FIRE",
			"OPTION_ATTR_WATER",
			"OPTION_ATTR_WIND",
			"OPTION_ATTR_EARTH",
			"OPTION_ATTR_DARK",
			"OPTION_ATTR_LIGHT",
			// 2009 Source (Missing in posterior versions)
			"OPTION_ATT_WATER_DOWN (2009)",
			"OPTION_ATT_WIND_DOWN (2009)",
			"OPTION_ATT_EARTH_DOWN (2009)",
			"OPTION_ALL_ATT_DOWN (2009)",
			// Standards
			"OPTION_MIX_STR",
			"OPTION_MIX_DEX",
			"OPTION_MIX_INT",
			"OPTION_MIX_CON",
			"OPTION_MIX_ATTACK",
			"OPTION_MIX_MAGIC",
			"OPTION_MIX_DEFENSE",
			"OPTION_MIX_RESIST",
			"OPTION_MIX_STURN",
			"OPTION_MIX_BLOOD",
			"OPTION_MIX_MOVE",
			"OPTION_MIX_POISON",
			"OPTION_MIX_SLOW",
			"OPTION_DOWN_LIMITLEVEL",
			"OPTION_INCREASE_INVEN",
			"OPTION_STEAL_MP",
			"OPTION_STEAL_HP",
			"OPTION_ATTACK_BLIND",
			"OPTION_ATTACK_POISON",
			"OPTION_ATTACK_CRITICAL",
			"OPTION_RECOVER_HP",
			"OPTION_RECOVER_MP",
			"OPTION_DECREASE_SKILL_DELAY",
			"OPTION_DECREASE_SKILL_MP",
			"OPTION_RESIST_STONE",
			"OPTION_RESIST_STURN",
			"OPTION_RESIST_SILENT",
			"OPTION_BLOCKING",
			"OPTION_MOVESPEED",
			"OPTION_FLYSPEED",
			"OPTION_ATTACK_DEADLY",
			"OPTION_STR_UP_RATE",
			"OPTION_DEX_UP_RATE",
			"OPTION_INT_UP_RATE",
			"OPTION_CON_UP_RATE",
			"OPTION_HP_UP_RATE",
			"OPTION_MP_UP_RATE",
			"OPTION_WEAPON_UP_RATE",
			"OPTION_ARMOR_UP_RATE",
			"OPTION_MELEE_HIT_UP_RATE",
			"OPTION_MAGIC_HIT_UP_RATE",
			"OPTION_MELEE_AVOID_RATE",
			"OPTION_MAGIC_AVOID_RATE",
			"OPTION_RECOVER_HP_RATE",
			"OPTION_RECOVER_MP_RATE",
			"OPTION_TEST_QUEST",
			"OPTION_EXP_UP_RATE",
			"OPTION_SP_UP_RATE",
			"OPTION_APET_TRANS_END",
			"OPTION_APET_ELEMENT_HPUP",
			"OPTION_APET_ELEMENT_ATTUP",
			"OPTION_ATT_FIRE_UP",
			"OPTION_ATT_WATER_UP",
			"OPTION_ATT_WIND_UP",
			"OPTION_ATT_EARTH_UP",
			"OPTION_ATT_DARK_UP",
			"OPTION_ATT_LIGHT_UP",
			"OPTION_DEF_FIRE_UP",
			"OPTION_DEF_WATER_UP",
			"OPTION_DEF_WIND_UP",
			"OPTION_DEF_EARTH_UP",
			"OPTION_DEF_DARK_UP",
			"OPTION_DEF_LIGHT_UP",
			"OPTION_ALL_STAT_UP",
			"OPTION_PVP_DAMAGE_ABSOLB",
			"OPTION_DEBUF_DECR_TIME",
			"OPTION_RECOVER_HP_NOTRATE",
			"OPTION_RECOVER_MP_NOTRATE",
			"OPTION_INCREASE_STRONG",
			"OPTION_INCREASE_HARD",
			"OPTION_INCREASE_HP",
			"OPTION_CLIENT_1",
			"OPTION_CLIENT_2",
			"OPTION_CLIENT_3",
			"OPTION_CLIENT_4",
			"OPTION_CLIENT_5",
			"OPTION_CLIENT_6",
			// NicolasG Custom
			"OPTION_SUSTAINER",
			"OPTION_REGEN_EP"
		};
	}
}
