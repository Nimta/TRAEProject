using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Buffs;
using TRAEProject.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Projectiles
{
    public class SummonStaffs : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.FlinxStaff:
                    item.useTime = 10;
                    item.useAnimation = 10;
                    item.autoReuse = true;
                    item.damage = 5; // down from 8
                    break;
                case ItemID.HornetStaff:
                    item.damage = 12;
                    item.useTime = 10;
                    item.useAnimation = 10;
                    item.autoReuse = true;
                    return;
                case ItemID.OpticStaff:
                    item.damage = 22; // down from 30
                    item.useTime = 10;
                    item.useAnimation = 10;
                    item.autoReuse = true;
                    break;
                case ItemID.BabyBirdStaff:
                case ItemID.ImpStaff:
                case ItemID.SpiderStaff:
                case ItemID.SanguineStaff:
                case ItemID.RavenStaff:
                case ItemID.Smolstar:
                case ItemID.PirateStaff:
                case ItemID.StormTigerStaff:
                case ItemID.XenoStaff:
                case ItemID.EmpressBlade:
                case ItemID.StardustCellStaff:
                case ItemID.StardustDragonStaff:
                    item.useTime = 10;
                    item.useAnimation = 10;
                    item.autoReuse = true;
                    break;
                case ItemID.PygmyStaff:
                    item.useTime = 10;
                    item.useAnimation = 10;
                    item.autoReuse = true;
                    item.damage = 45; // up from 34
                    break;
                case ItemID.TempestStaff:
                    item.useTime = 10;
                    item.useAnimation = 10;
                    item.autoReuse = true;
                    item.damage = 42;
                    break;
                case ItemID.DeadlySphereStaff:
                    item.damage = 15; // down from 50
                    item.useTime = 10;
                    item.useAnimation = 10;
                    item.autoReuse = true;
                    return;
            }
        }
    }
    public class MinionChanges : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Projectile projectile)
        {
            switch (projectile.type)
            {
                case ProjectileID.MiniSharkron:
                    return;
                case ProjectileID.FlinxMinion:
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 20;
                    return;
                case ProjectileID.Tempest:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 15;
                    return;
                case ProjectileID.Retanimini:
                case ProjectileID.Spazmamini:
                    projectile.tileCollide = false;
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 30;
                    return;
                case ProjectileID.MiniRetinaLaser:
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homesIn = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homingRange = 150f;
                    projectile.penetrate = 1;
                    return;
                case ProjectileID.CoolWhip:
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuff = BuffType<CoolWhipTag>();
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuffDuration = 240;
                    return;
                case ProjectileID.DeadlySphere:
                    projectile.extraUpdates = 1;
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 30;
                    return;
                case ProjectileID.DangerousSpider:
                case ProjectileID.VenomSpider:
                case ProjectileID.JumperSpider:
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 30;
                    return;
                case ProjectileID.HornetStinger:
                    projectile.extraUpdates = 2;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homesIn = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homingRange = 150f;
                    return;
                case ProjectileID.Smolstar:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 53; // up from 40
                    return;
                case ProjectileID.ImpFireball:
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 60;
                    return;
                case ProjectileID.VampireFrog:
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 60; // up from 10, static 
                    return;
            }

        }
        public override void AI(Projectile projectile)
        {
            switch (projectile.type)
            {
                case ProjectileID.FlyingImp:
                    if (projectile.ai[1] > 0f)
                    {
                        projectile.ai[1] -= 0.33f;
                    }
                    return;
                case ProjectileID.DeadlySphere:
                    projectile.ai[1] += 2f;
                    return;
                case ProjectileID.BatOfLight:
                    projectile.localNPCHitCooldown = (int)projectile.ai[0];
                    return;
                case ProjectileID.Smolstar:
                    {
                        if (projectile.ai[0] == -1f)
                        {
                            projectile.ai[1] -= 0.33f; // when it reaches 9f, attack. 						
                        }
                        return;
                    }

            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if ((projectile.minion || ProjectileID.Sets.MinionShot[projectile.type]) && target.HasBuff(BuffID.RainbowWhipNPCDebuff) && crit == true)
            {
                float VelocityX = Main.rand.Next(-35, 36) * 0.02f;
                float VelocityY = Main.rand.Next(-35, 36) * 0.02f;
                VelocityX *= 10f;
                VelocityY *= 10f;
                Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), target.Center.X, target.Center.Y, VelocityX, VelocityY, ProjectileType<KaleidoscopeProjectile>(), (int)(projectile.damage * 0.5), 0, projectile.owner, 0, 0f);
            }
            switch (projectile.type)
            {
                case ProjectileID.JumperSpider:
                case ProjectileID.VenomSpider:
                case ProjectileID.DangerousSpider:
                    {
                        projectile.localAI[1] = 30f; // up from 20
                        return;
                    }
            }
        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type])
            {
                damage += target.GetGlobalNPC<ChangesNPCs>().TagDamage;
                if (Main.rand.Next(100) < target.GetGlobalNPC<ChangesNPCs>().TagCritChance)
                {
                    crit = true;
                }
                if (Main.rand.Next(100) < Main.player[projectile.owner].GetModPlayer<TRAEPlayer>().minionCritChance)
                {
                    crit = true;
                }
            }
        }
        NPC target;
        Projectile hook;
        public override bool PreAI(Projectile projectile)
        {
            if (projectile.type == ProjectileID.PirateCaptain || projectile.type == ProjectileID.OneEyedPirate || projectile.type == ProjectileID.SoulscourgePirate)
            {
                //Main.NewText(projectile.ai[0] + ", " + projectile.ai[1] + ", " + projectile.localAI[0] + ", " + projectile.localAI[1]);
                //Main.NewText(projectile.frame);
                if (hook != null && hook.active)
                {
                    if (hook.ai[1] == 1)
                    {
                        projectile.tileCollide = false;
                        projectile.ai[0] = 0;
                        projectile.velocity = (hook.Center - projectile.Center).SafeNormalize(-Vector2.UnitY) * 15f;
                        projectile.spriteDirection = Math.Sign(projectile.velocity.X);
                        projectile.frame = 14;
                        if ((hook.Center - projectile.Center).Length() < 20)
                        {
                            hook.Kill();
                            hook = null;
                        }

                        Player player = Main.player[projectile.owner];
                        if (Main.player[projectile.owner].dead)
                        {
                            Main.player[projectile.owner].pirateMinion = false;
                        }
                        if (Main.player[projectile.owner].pirateMinion)
                        {
                            projectile.timeLeft = 2;
                        }
                        return false;
                    }
                }
                else
                {
                    projectile.tileCollide = true;
                    projectile.localAI[1] += 1f;
                    if (projectile.localAI[1] > 120f)
                    {
                        if (TRAEMethods.ClosestNPC(ref target, 2000, projectile.Center, false, Main.player[projectile.owner].MinionAttackTargetNPC))
                        {
                            if (target.Distance(projectile.Center) > 300 || projectile.ai[0] == 1)
                            {
                                projectile.localAI[1] = 0;
                                hook = Main.projectile[Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), projectile.Center, TRAEMethods.PolarVector(12, (target.Center - projectile.Center).ToRotation()), ProjectileType<PirateHook>(), projectile.damage, 0, projectile.owner)];
                                for (int n = 0; n < 200; n++)
                                {
                                    if (Main.npc[n] != target)
                                    {
                                        hook.localNPCImmunity[n] = -1;
                                    }
                                }
                                hook.ai[0] = target.whoAmI;
                            }
                        }
                    }
                }
            }
            if (projectile.type == ProjectileID.Tempest)
            {
                //linking the minion to the player
                Player player = Main.player[projectile.owner];
                if (Main.player[projectile.owner].dead)
                {
                    Main.player[projectile.owner].sharknadoMinion = false;
                }
                if (Main.player[projectile.owner].sharknadoMinion)
                {
                    projectile.timeLeft = 2;
                }

                //sharknados push each other when too close
                float disturbanceVelocity = 0.1f;
                float disturbanceDistance = projectile.width;
                disturbanceDistance *= 2f;
                for (int m = 0; m < 1000; m++)
                {
                    if (m != projectile.whoAmI && Main.projectile[m].active && Main.projectile[m].owner == projectile.owner && Main.projectile[m].type == projectile.type && Math.Abs(projectile.position.X - Main.projectile[m].position.X) + Math.Abs(projectile.position.Y - Main.projectile[m].position.Y) < disturbanceDistance)
                    {
                        if (projectile.position.X < Main.projectile[m].position.X)
                        {
                            projectile.velocity.X -= disturbanceVelocity;
                        }
                        else
                        {
                            projectile.velocity.X += disturbanceVelocity;
                        }
                        if (projectile.position.Y < Main.projectile[m].position.Y)
                        {
                            projectile.velocity.Y -= disturbanceVelocity;
                        }
                        else
                        {
                            projectile.velocity.Y += disturbanceVelocity;
                        }
                    }
                }

                //manage alpha
                projectile.tileCollide = false;
                if (Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {
                    projectile.alpha += 20;
                    if (projectile.alpha > 150)
                    {
                        projectile.alpha = 150;
                    }
                }
                else
                {
                    projectile.alpha -= 50;
                    if (projectile.alpha < 60)
                    {
                        projectile.alpha = 60;
                    }
                }

                //movement
                if (!Collision.CanHitLine(projectile.Center, 1, 1, Main.player[projectile.owner].Center, 1, 1))
                {
                    projectile.ai[0] = 1f;
                }
                float speed = 16f;
                Vector2 diff = player.Center - projectile.Center + new Vector2(0f, -20f);
                float num25 = diff.Length();
                if (num25 > 200f)
                {
                    speed = 32f;
                }
                if (num25 < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {
                    projectile.ai[0] = 0f;
                    projectile.netUpdate = true;
                }
                if (num25 > 2000f)
                {
                    projectile.position.X = Main.player[projectile.owner].Center.X - (float)(projectile.width / 2);
                    projectile.position.Y = Main.player[projectile.owner].Center.Y - (float)(projectile.width / 2);
                }

                if (Math.Abs(diff.X) > 40f || Math.Abs(diff.Y) > 10f)
                {
                    diff.Normalize();
                    diff *= speed;
                    diff *= new Vector2(1.25f, 0.65f);
                    projectile.velocity = (projectile.velocity * 20f + diff) / 21f;
                }
                else
                {
                    if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
                    {
                        projectile.velocity.X = -0.15f;
                        projectile.velocity.Y = -0.05f;
                    }
                    projectile.velocity *= 1.01f;
                }

                //animation and dust
                int num27 = 2;
                projectile.frameCounter++;
                if (projectile.frameCounter >= 6 * num27)
                {
                    projectile.frameCounter = 0;
                }
                projectile.frame = projectile.frameCounter / num27;
                if (Main.rand.Next(5) == 0)
                {
                    int num28 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 217, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num28].velocity *= 0.3f;
                    Main.dust[num28].noGravity = true;
                    Main.dust[num28].noLight = true;
                }
                if (projectile.velocity.X > 0f)
                {
                    projectile.spriteDirection = (projectile.direction = -1);
                }
                else if (projectile.velocity.X < 0f)
                {
                    projectile.spriteDirection = (projectile.direction = 1);
                }

                //attack cooldown
                projectile.ai[1] += 1f;
                if (Main.rand.Next(3) != 0)
                {
                    projectile.ai[1] += 1f;
                }
                if (projectile.ai[1] > 50f)
                {

                    if (TRAEMethods.ClosestNPC(ref target, 500 * 16, player.Center, false, player.MinionAttackTargetNPC))
                    {

                        if (Main.myPlayer == projectile.owner)
                        {
                            float shootSpeed = 20;
                            float calculatedShootAngle = TRAEMethods.PredictiveAim(projectile.Center, shootSpeed, target.Center, target.velocity, out _);
                            if (!float.IsNaN(calculatedShootAngle))
                            {
                                Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), projectile.Center, TRAEMethods.PolarVector(shootSpeed, calculatedShootAngle), ProjectileID.MiniSharkron, projectile.damage, projectile.knockBack, projectile.owner);
                            }



                        }
                        projectile.ai[1] = 0f;
                        projectile.netUpdate = true;
                    }

                }


                return false;
            }
            if (projectile.type == ProjectileID.MiniSharkron)
            {
                projectile.ai[0] = projectile.timeLeft < (3600 - (16 * 5000) / 10) ? 45 : 0;
            }
            return base.PreAI(projectile);
        }
        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            if (projectile.type == ProjectileID.PirateCaptain || projectile.type == ProjectileID.OneEyedPirate || projectile.type == ProjectileID.SoulscourgePirate)
            {
                if (hook != null && hook.active && hook.type == ProjectileType<PirateHook>())
                {
                    Vector2 mountedCenter = hook.Center;

                    float num128 = projectile.Center.X;
                    float num129 = projectile.Center.Y;
                    float x9 = projectile.velocity.X;
                    float num130 = projectile.velocity.Y;
                    if (x9 == 0f && num130 == 0f)
                    {
                        num130 = 0.0001f;
                        num130 = 0.0001f;
                    }
                    float num131 = (float)Math.Sqrt(x9 * x9 + num130 * num130);
                    num131 = 20f / num131;
                    if (projectile.ai[0] == 0f)
                    {
                        num128 -= projectile.velocity.X * num131;
                        num129 -= projectile.velocity.Y * num131;
                    }
                    else
                    {
                        num128 += projectile.velocity.X * num131;
                        num129 += projectile.velocity.Y * num131;
                    }
                    Vector2 vector26 = new Vector2(num128, num129);
                    x9 = mountedCenter.X - vector26.X;
                    num130 = mountedCenter.Y - vector26.Y;
                    float rotation22 = (float)Math.Atan2(num130, x9) - 1.57f;
                    if (projectile.alpha == 0)
                    {
                        int num132 = -1;
                        if (projectile.position.X + (float)(projectile.width / 2) < mountedCenter.X)
                        {
                            num132 = 1;
                        }
                    }
                    bool flag24 = true;
                    while (flag24)
                    {
                        float num133 = (float)Math.Sqrt(x9 * x9 + num130 * num130);
                        if (num133 < 25f)
                        {
                            flag24 = false;
                            continue;
                        }
                        if (float.IsNaN(num133))
                        {
                            flag24 = false;
                            continue;
                        }
                        num133 = 12f / num133;
                        x9 *= num133;
                        num130 *= num133;
                        vector26.X += x9;
                        vector26.Y += num130;
                        x9 = mountedCenter.X - vector26.X;
                        num130 = mountedCenter.Y - vector26.Y;
                        Microsoft.Xna.Framework.Color color30 = Lighting.GetColor((int)vector26.X / 16, (int)(vector26.Y / 16f));
                        Main.EntitySpriteDraw(TextureAssets.Chain.Value, new Vector2(vector26.X - Main.screenPosition.X, vector26.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle(0, 0, TextureAssets.Chain.Width(), TextureAssets.Chain.Height()), color30, rotation22, new Vector2((float)TextureAssets.Chain.Width() * 0.5f, (float)TextureAssets.Chain.Height() * 0.5f), 1f, SpriteEffects.None, 0);
                    }
                }
            }
            return base.PreDraw(projectile, ref lightColor);
        }
    }
    public class SummonTags : GlobalBuff
    {
        
        public override void Update(int type, NPC npc, ref int buffIndex)
        {
            switch (type)
            {
                case BuffID.MaceWhipNPCDebuff:
                    npc.GetGlobalNPC<ChangesNPCs>().TagCritChance += 15;
                    return;
                case BuffID.RainbowWhipNPCDebuff:
                    npc.GetGlobalNPC<ChangesNPCs>().TagCritChance += 10;
                    return;
            }
        }
    }
    public class PirateHook : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.MinionShot[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;

            Projectile.aiStyle = -1;
            Projectile.extraUpdates = 1;
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 720;
            Projectile.DamageType = DamageClass.Summon;
        }

        public override void AI()
        {
            NPC target = Main.npc[(int)Projectile.ai[0]];
            Projectile.timeLeft = 2;
            if (Projectile.ai[1] != 1)
            {
                if (target != null && target.active)
                {
                    Projectile.velocity = (target.Center - Projectile.Center).SafeNormalize(-Vector2.UnitY) * 14f;
                    Projectile.rotation = Projectile.velocity.ToRotation() + (float)Math.PI / 2f;
                }
                else
                {
                    Projectile.Kill();
                }

            }
            else
            {
                Sticking();
            }
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Projectile.ai[1] = 1;
        }
        void Sticking()
        {
            int aiFactor = 15; // Change projectile factor to change the 'lifetime' of projectile sticking javelin
            bool killProj = false; // if true, kill projectile at the end
            bool hitEffect = false; // if true, perform a hit effect
            Projectile.localAI[0] += 1f;
            // Every 30 ticks, the javelin will perform a hit effect
            hitEffect = Projectile.localAI[0] % 30f == 0f;
            int projTargetIndex = (int)Projectile.ai[0];
            if (Projectile.localAI[0] >= (float)(60 * aiFactor)// If it's time for projectile javelin to die, kill it
                || (projTargetIndex < 0 || projTargetIndex >= 200)) // If the index is past its limits, kill it
            {
                killProj = true;
            }
            else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage) // If the target is active and can take damage
            {
                // Set the projectile's position relative to the target's center
                Projectile.Center = Main.npc[projTargetIndex].Center - Projectile.velocity * 2f;
                Projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
                if (hitEffect) // Perform a hit effect here
                {
                    Main.npc[projTargetIndex].HitEffect(0, 1.0);
                }
            }
            else // Otherwise, kill the projectile
            {
                killProj = true;
            }

            if (killProj) // Kill the projectile
            {
                Projectile.Kill();
            }
        }
    }
}