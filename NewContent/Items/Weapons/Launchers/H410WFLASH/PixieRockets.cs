using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using TRAEProject.Changes.Projectiles;
using TRAEProject.Changes.Weapon.Ranged.Rockets;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.Items.Weapons.Launchers.H410WFLASH
{
    public class PixieRockets : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool PixieExplosion = false;
        public void PixieRocketAI(Projectile projectile)
        {     
		projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.ai[0] < 25)
            {
                ++projectile.ai[0];
            }
            /// control it
            else 
            {
                Vector2 move = Vector2.Zero;
                bool target = false;
                float distance = 3000f;
                for (int k = 0; k < 200; k++)
                {
                    Vector2 newMove = Main.MouseWorld - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
                if (target)
                {
                    float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                    if (magnitude > 10f)
                    {
                        move /= magnitude;
                    }
                    projectile.velocity += move * 2f;
                    projectile.velocity *= 0.95f;
                }
            }
			/// Dusts
                if ((Math.Abs(projectile.velocity.X) >= 8f || Math.Abs(projectile.velocity.Y) >= 8f) && Main.rand.Next(2) == 0)
                {

                        float positionX = 0f;
                        float positionY = 0f;
                        positionX = projectile.velocity.X * 0.5f;
                        positionY = projectile.velocity.Y * 0.5f;
                        
                        Vector2 position71 = new Vector2(projectile.position.X + 3f + positionX, projectile.position.Y + 3f + positionY) - projectile.velocity * 0.5f;
                        int width67 = projectile.width - 8;
                        int height67 = projectile.height - 8;
                        Dust dust = Dust.NewDustDirect(position71, width67, height67, 6, 0f, 0f, 100, default, 1f);
                        dust.scale *= 2f + Main.rand.Next(10) * 0.1f;
                        dust.velocity *= 0.2f;
                        dust.noGravity = true;
                        Vector2 position72 = new Vector2(projectile.position.X + 3f + positionX, projectile.position.Y + 3f + positionY) - projectile.velocity * 0.5f;
                        int width68 = projectile.width - 8;
                        int height68 = projectile.height - 8;
                        Dust otherdust = Dust.NewDustDirect(position72, width68, height68, DustID.Pixie, 0f, 0f, 100, default, 0.5f);
                        otherdust.fadeIn = 1f + Main.rand.Next(5) * 0.1f;
                        otherdust.velocity *= 0.05f;
                    
			    }
                if (Math.Abs(projectile.velocity.X) < 15f && Math.Abs(projectile.velocity.Y) < 15f)
                {
                    projectile.velocity *= 1.1f;
                }
        }
        public void HallowExplosion(Projectile projectile)
        {
                SoundEngine.PlaySound(SoundID.Item14, projectile.position);
                float num846 = 3f;
                for (int num847 = 0; num847 < 30; num847++)
                {
                    Dust dust53 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
                    dust53.velocity = (dust53.position - projectile.Center).SafeNormalize(Vector2.Zero);
                    Dust dust = dust53;
                    dust.velocity *= 2f + (float)Main.rand.Next(5) * 0.1f;
                    dust53.velocity.Y -= num846 * 0.5f;
                    dust53.color = Color.Pink * 0.9f;
                    if (Main.rand.Next(2) == 0)
                    {
                        dust53.scale = 0.5f;
                        dust53.fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                        dust53.color = Color.Yellow * 0.8f;
                    }
                }
                for (int num848 = 0; num848 < 20; num848++)
                {
                    Dust dust54 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 100);
                dust54.noGravity = true;
                    dust54.fadeIn = 1.4f;
                    dust54.velocity = (dust54.position - projectile.Center).SafeNormalize(Vector2.Zero);
                    Dust dust = dust54;
                    dust.velocity *= 5.5f + (float)Main.rand.Next(61) * 0.1f;
                    dust54.velocity.Y -= num846 * 0.5f;
                    dust54 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.Pixie, 0f, 0f, 100);
                    dust54.velocity = (dust54.position - projectile.Center).SafeNormalize(Vector2.Zero);
                    dust54.velocity.Y -= num846 * 0.25f;
                    dust = dust54;
                    dust.velocity *= 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    dust54.fadeIn = 0f;
                    dust54.scale = 0.6f;
                    dust54 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                    dust54.noGravity = num848 % 2 == 0;
                    dust54.velocity = (dust54.position - projectile.Center).SafeNormalize(Vector2.Zero);
                    dust = dust54;
                    dust.velocity *= 3f + (float)Main.rand.Next(21) * 0.2f;
                    dust54.velocity.Y -= num846 * 0.5f;
                    dust54.fadeIn = 1.2f;
                    if (!dust54.noGravity)
                    {
                        dust54.scale = 0.4f;
                        dust54.fadeIn = 0f;
                    }
                    else
                    {
                        dust = dust54;
                        dust.velocity *= 2f + (float)Main.rand.Next(5) * 0.2f;
                        dust54.velocity.Y -= num846 * 0.5f;
                    }
                }

        }
        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if (PixieExplosion)
            {
                HallowExplosion(projectile);
            }

        }
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (PixieExplosion)
            {
                HallowExplosion(projectile);
                return false;
            }
            return true;
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (PixieExplosion)
            {
               HallowExplosion(projectile);
            }
        }
    }
    public class PixieRocket : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.height = 20;
            Projectile.width = 20;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 4;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.timeLeft = 300;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<PixieRockets>().PixieExplosion = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
    }
    public class DestructivePixie : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
        public override void Kill(int timeLeft)
        {
            Projectile.GetGlobalProjectile<PixieRockets>().HallowExplosion(Projectile);
            Projectile.GetGlobalProjectile<NewRockets>().DestroyTiles(Projectile, 3);
        }
    }
    public class SuperPixie : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
            AIType = ProjectileType<PixieRocket>();
            Projectile.penetrate = 6;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<PixieRockets>().PixieExplosion = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 180;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
    }
    public class DirectPixie : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
            AIType = ProjectileType<PixieRocket>();
            Projectile.extraUpdates = 1;
            Projectile.penetrate = 3;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().DirectDamage = 1.5f;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 80;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionDamage = 0.67f;
            Projectile.GetGlobalProjectile<PixieRockets>().PixieExplosion = true;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
    }
    public class MiniNukePixie : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
            AIType = ProjectileType<PixieRocket>();
            Projectile.penetrate = 8;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<PixieRockets>().PixieExplosion = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 250;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
    }
    public class DestructiveMiniNukePixie : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
            AIType = ProjectileType<PixieRocket>();
            Projectile.penetrate = 8;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<PixieRockets>().PixieExplosion = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 250;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
      
        }
        public override void Kill(int timeLeft)
        {
            Projectile.GetGlobalProjectile<PixieRockets>().HallowExplosion(Projectile);
            Projectile.GetGlobalProjectile<NewRockets>().DestroyTiles(Projectile, 3);
        }
    }
    public class ClusterPixie : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
            AIType = ProjectileType<PixieRocket>();
            Projectile.penetrate = 4;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<PixieRockets>().PixieExplosion = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
        public override void Kill(int timeLeft)
        {
            if (Projectile.owner == Main.myPlayer)
            {
                int Cluster = 862; // snowman cannon's projectile, doesn't damage the player
                float num852 = ((float)Math.PI * 2f);
                for (float c = 0f; c < 1f; c += 355f / (678f * (float)Math.PI))
                {
                    float f2 = num852 + c * ((float)Math.PI * 2f);
                    Vector2 velocity = f2.ToRotationVector2() * (4f + Main.rand.NextFloat() * 2f);
                    velocity += Vector2.UnitY * -1f;
                    int num854 = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center, velocity, Cluster, Projectile.damage / 4, 0f, Projectile.owner);
                    Projectile pRojectile = Main.projectile[num854];
                    Projectile projectile2 = pRojectile;
                    projectile2.timeLeft = 30;
                }
            }
        }
    }
    public class HeavyPixie: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
            AIType = ProjectileType<PixieRocket>();
            Projectile.penetrate = 4;
            Projectile.GetGlobalProjectile<NewRockets>().HeavyRocket = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<PixieRockets>().PixieExplosion = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
    }
    public class DryPixie : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
            AIType = ProjectileType<PixieRocket>();
            Projectile.penetrate = 4;
            Projectile.GetGlobalProjectile<NewRockets>().DryRocket = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
    }
    public class WetPixie : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
            AIType = ProjectileType<PixieRocket>();
            Projectile.penetrate = 4;
            Projectile.GetGlobalProjectile<NewRockets>().WetRocket = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
    }
    public class LavaPixie : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
            AIType = ProjectileType<PixieRocket>();
            Projectile.penetrate = 4;
            Projectile.GetGlobalProjectile<NewRockets>().LavaRocket = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
    }
    public class HoneyPixie : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<PixieRocket>());
            AIType = ProjectileType<PixieRocket>();
            Projectile.penetrate = 4;
            Projectile.GetGlobalProjectile<NewRockets>().HoneyRocket = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<PixieRockets>().PixieRocketAI(Projectile);
        }
    }
}