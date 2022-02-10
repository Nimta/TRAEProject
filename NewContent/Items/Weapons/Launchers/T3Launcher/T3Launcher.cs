using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.NewContent.Items.Weapons.Launchers.T3Launcher
{
    class AdamantiteLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Launcher");
            Tooltip.SetDefault("Shoots Rockets");
        }
        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 22;
            Item.damage = 60;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 3);
            Item.DamageType = DamageClass.Ranged;
            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.RocketI;
            Item.knockBack = 8f;
            Item.shootSpeed = 7f;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.AdamantiteBar, 18)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(-16f, -5f);
		}
    }
    class TitaniumBazooka : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titanium Bazooka");
            Tooltip.SetDefault("Shoots three to four Rockets in one shot");
        }
        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 22;
            Item.damage = 48;
            Item.useAnimation = 51;
            Item.useTime = 51;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 3);
            Item.DamageType = DamageClass.Ranged;
            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.RocketI;
            Item.knockBack = 8f;
            Item.shootSpeed = 7f;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
        }
	    public override Vector2? HoldoutOffset() {
			return new Vector2(-16f, -5f);
		}
        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 3 + Main.rand.Next(2); // 3 or 4 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(30));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.TitaniumBar, 18)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}