﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TRAEProject.Items.FlamethrowerAmmo;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Items.DreadItems.BossBag
{
    class DreadBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 60;
            Item.height = 34;
            Item.rare = 9;
            Item.expert = true;
            //bossBagNPC = mod.NPCType("WeakPoint");
        }

        public override int BossBagNPC => NPCID.BloodNautilus;

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            int mainLoot = 0;
            switch (Main.rand.Next(4))
            {
                case 0:
                    mainLoot = ItemType<ShellSpinner.ShellSpinner>();
                    break;
                case 1:
                    mainLoot = ItemType<BloodBoiler.BloodBoiler>(); 
                    break;
                case 2:
                    mainLoot = ItemType<Brimstone.Brimstone>();
                    break;
                case 3:
                    mainLoot = ItemID.SanguineStaff;
                    break;
            }
            player.QuickSpawnItem(mainLoot);
            if (mainLoot == ItemType<BloodBoiler.BloodBoiler>())
                player.QuickSpawnItem(ItemType<BloodyGel>(), 100);
            if (Main.rand.Next(8) == 0)
            {
                player.QuickSpawnItem(ItemID.BloodHamaxe);
            }
            if (Main.rand.Next(6) == 0)
            {
                player.QuickSpawnItem(ItemType<BloodWings.BloodWings>());
            }
            if (Main.rand.Next(9) == 0)
            {
                player.QuickSpawnItem(ItemID.BloodMoonMonolith);
            }
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemType<DreadMask.DreadMask>());
            }
            if (Main.rand.Next(9) == 0)
            {
                player.QuickSpawnItem(ItemType<BottomlessChumBucket.BottomlessChumBucket>());
            }
            else
            {
                player.QuickSpawnItem(ItemID.ChumBucket, Main.rand.Next(20, 30));
            }
            player.QuickSpawnItem(ItemID.BloodMoonStarter);
            player.QuickSpawnItem(ItemType<RedPearl.RedPearl>());
        }
    }
}
