﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TRAEProject.Common.ModPlayers;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.Items.Accesories.MechanicalEye
{
    public class AlphaScope : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Alpha Scope");
            Tooltip.SetDefault("80% increased ranged velocity\nRockets, guns and arrows smart bounce and stun enemies on critical hits\n'Prepare to be Terminated'");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = 100000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RangedStats>().AlphaScope += 1;
            player.GetModPlayer<RangedStats>().rangedVelocity += 0.8f;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.ReconScope, 1)
                .AddIngredient(ItemType<MechanicalEyeItem>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }

}
