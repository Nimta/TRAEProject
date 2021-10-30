﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Items
{
    public class Bags : GlobalItem
    {
		public static readonly int[] PlanteraLoot = new int[] { ItemID.HellwingBow, ItemID.Flamelash, ItemID.FlowerofFire, ItemID.Sunfury };

		public override bool PreOpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
			{
				player.QuickSpawnItem(ItemID.BoneGlove, 1);
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(ItemID.SkeletronHand, 1);
				if (Main.rand.Next(3) == 0)
					player.QuickSpawnItem(ItemID.SkeletronMask, 1);
				return false;
			}
			if (context == "bossBag" && arg == ItemID.PlanteraBossBag) // TO DO
			{
				player.TryGettingDevArmor();
				if (Main.rand.Next(7) == 0)
				{
					player.QuickSpawnItem(ItemID.PlanteraMask);
				}
				player.QuickSpawnItem(ItemID.TempleKey);
				player.QuickSpawnItem(ItemID.SporeSac);
				if (Main.rand.Next(15) == 0)
				{
					player.QuickSpawnItem(ItemID.Seedling);
				}
				if (Main.rand.Next(20) == 0)
				{
					player.QuickSpawnItem(ItemID.TheAxe);
				}
				if (Main.rand.Next(2) == 0)
				{
					player.QuickSpawnItem(ItemID.PygmyStaff);
				}
				if (Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(ItemID.ThornHook);
				}
				switch (Main.rand.Next(3))
				{
					case 0:
						player.QuickSpawnItem(ItemID.GrenadeLauncher);
						player.QuickSpawnItem(ItemID.RocketI, Main.rand.Next(50, 150));
						player.QuickSpawnItem(ItemID.VenusMagnum);
						break;
					case 1:
						player.QuickSpawnItem(ItemID.Seedler);
						player.QuickSpawnItem(ItemID.FlowerPow);
						break;
					case 2:
						player.QuickSpawnItem(ItemID.LeafBlower);
						player.QuickSpawnItem(ItemID.NettleBurst);
						break;
				}
				return false;
			}
			if (context == "bossBag" && arg == ItemID.FairyQueenBossBag) // TO DO
			{
				player.TryGettingDevArmor();
				player.QuickSpawnItem(ItemID.EmpressFlightBooster);
				if (Main.rand.Next(7) == 0)
				{
					player.QuickSpawnItem(ItemID.FairyQueenMask);
				}
				if (Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(ItemID.RainbowWings);
				}
				if (Main.rand.Next(20) == 0)
				{
					player.QuickSpawnItem(ItemID.SparkleGuitar);
				}
				if (Main.rand.Next(4) == 0)
				{
					player.QuickSpawnItem(ItemID.HallowBossDye);
				}
				if (Main.rand.Next(20) == 0)
				{
					player.QuickSpawnItem(ItemID.RainbowCursor);
				}
				switch (Main.rand.Next(4))
				{
					case 0:
						player.QuickSpawnItem(ItemID.PiercingStarlight);
						break;
					case 1:
						player.QuickSpawnItem(ItemID.FairyQueenMagicItem);
						break;
					case 2:
						player.QuickSpawnItem(ItemID.FairyQueenRangedItem);
						break;
					case 3:
						player.QuickSpawnItem(ItemID.RainbowCrystalStaff);
						break;
				}
				return false;
			}
			if (context == "bossBag" && arg == ItemID.MoonLordBossBag) // TO DO
			{
				player.TryGettingDevArmor();
				if (Main.rand.Next(7) == 0)
				{
					player.QuickSpawnItem(ItemID.BossMaskMoonlord);
				}
				if (Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(ItemID.MeowmereMinecart);
				}
				if (!player.HasItem(ItemID.PortalGun))
				{
					player.QuickSpawnItem(3384);
				}
				player.QuickSpawnItem(ItemID.LunarOre, Main.rand.Next(90, 111));
				player.QuickSpawnItem(ItemID.GravityGlobe);
				player.QuickSpawnItem(ItemID.SuspiciousLookingTentacle);
				player.QuickSpawnItem(4954); // celestial starboard
				int item = Utils.SelectRandom<int>(Main.rand, 3063, 3389, 3065, 1553, 3930, 3541, 3570, ItemID.RainbowWhip, ItemID.StardustDragonStaff);
				player.QuickSpawnItem(item); 
				return false;
			}

				if (context == "crate" && (arg == ItemID.OasisCrate || arg == ItemID.OasisCrateHard))
			{
				int index = Main.rand.Next(ChangesWorld.PyramidItems.Length);
				int itemWhoAmI = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ChangesWorld.PyramidItems[index], 1, noBroadcast: false, -1);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, itemWhoAmI, 1f);
				}

				if (Main.rand.Next(4) == 0)
				{
					int bombAmount = Main.rand.Next(4, 7);
					int itemWhoAmI2 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.ScarabBomb, bombAmount);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, itemWhoAmI2, 1f);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int fossilAmount = Main.rand.Next(10, 17);
					int itemWhoAmI3 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.FossilOre, fossilAmount);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, itemWhoAmI3, 1f);
					}
				}
				FishingCrateLoot(player, arg);
				return false;
			}
			if (context == "lockBox" && arg == ItemID.ObsidianLockbox)
			{
				int index = Main.rand.Next(ChangesWorld.ShadowItems.Length);
				int number = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ChangesWorld.ShadowItems[index], 1, noBroadcast: false, -1);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number, 1f);
				}
				return false;
			}
			return true;
		}
		void FishingCrateLoot(Player player, int crateItemID)
        {
			if (Main.rand.Next(4) == 0)
			{
				int num28 = Main.rand.Next(6);
				switch (num28)
				{
					case 0:
						num28 = 288;
						break;
					case 1:
						num28 = 296;
						break;
					case 2:
						num28 = 304;
						break;
					case 3:
						num28 = 305;
						break;
					case 4:
						num28 = 2322;
						break;
					case 5:
						num28 = 2323;
						break;
				}
				int stack35 = Main.rand.Next(2, 5);
				int number55 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, num28, stack35);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number55, 1f);
				}
			}
			if (Main.rand.Next(2) == 0)
			{
				int type28 = Main.rand.Next(188, 190);
				int stack36 = Main.rand.Next(5, 18);
				int number56 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, type28, stack36);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number56, 1f);
				}
			}
			if (Main.rand.Next(2) == 0)
			{
				int type29 = ((Main.rand.Next(2) != 0) ? 2675 : 2676);
				int stack37 = Main.rand.Next(2, 7);
				int number57 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, type29, stack37);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number57, 1f);
				}
			}
			bool hardmode = ItemID.Sets.IsFishingCrateHardmode[crateItemID];
			if (!hardmode)
			{
				return;
			}
			if (Main.rand.Next(2) == 0)
			{
				int type37 = 521;
				if (crateItemID == 3986)
				{
					type37 = 520;
				}
				int stack40 = Main.rand.Next(2, 6);
				int number65 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, type37, stack40);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number65, 1f);
				}
			}
			if (Main.rand.Next(2) == 0)
			{
				int type38 = 522;
				int stack41 = Main.rand.Next(2, 6);
				switch (crateItemID)
				{
					case 3983:
						type38 = 1332;
						break;
					case 3986:
						type38 = 502;
						stack41 = Main.rand.Next(4, 11);
						break;
				}
				int number66 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, type38, stack41);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number66, 1f);
				}
			}
		}
    }
}
