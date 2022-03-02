using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.NPCs.Banners;
using TRAEProject.Items.Weapons.Underworld.WillOfTheWisp;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NPCs.Boomxie

{
    public class Boomxie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boomxie"); // Automatic from .lang files
            Main.npcFrameCount[NPC.type] = 4; // make sure to set this for your modnpcs.
        }
        public override void SetDefaults()
        {
            NPC.width = 38;
            NPC.height = 40;

            AIType = NPCID.Pixie;
            AnimationType = NPCID.Pixie;
            NPC.damage = 50;
            NPC.defense = 10;
            NPC.lifeMax = 100;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.HitSound = SoundID.NPCHit5;
            NPC.knockBackResist = 0.5f;

            Banner = NPC.type;
            BannerItem = ItemType<BoomxieBanner>();
        }
        int timer = 0;
        public override void AI()
        {
<<<<<<< Updated upstream:NPCs/Boomxie/Boomxie.cs
            timer++;
            if (timer >= 60)
            { 
                NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y, NPCType<LittleBoomxie>()); 
				timer = 0;
=======
          
            attackCycleTimer++;
            if (attackCycleTimer > 150)
            {
                spamTimer++;
                if (spamTimer >= 75)
                {
                    NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.Center.X, (int)NPC.Center.Y, NPCType<LittleBoomxie>());
                    spamTimer = 0;
                }
            }
            if (attackCycleTimer > 750)
            {
                attackCycleTimer = 0;
>>>>>>> Stashed changes:NewContent/NPCs/Boomxie/Boomxie.cs
            }
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // Sets the description of this NPC that is listed in the bestiary
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement>
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
                new FlavorTextBestiaryInfoElement("The adult stage of Lavaflies. They defend themselves by leaving some of their volatile dust behind. ")
            }); 
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneUnderworldHeight)
            {
                return 0.15f;
            }
            return 0f;
        }
        int damagestored = 0;
        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            damagestored += damage;
            if (damagestored > 10)
            {
                int smallBoomxiesToSpawn = damagestored / 30;
                for (int i = 0; i < smallBoomxiesToSpawn; i++)
                {
                    damagestored -= 10;
                    NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.Center.X, (int)NPC.Center.Y, NPCType<LittleBoomxie>());
                }
            }
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            damagestored += damage;
            if (damagestored > 50)
            {
                int smallBoomxiesToSpawn = damagestored / 10;
                for (int i = 0; i < smallBoomxiesToSpawn; i++)
                {
                    damagestored -= 50;
                    NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.Center.X, (int)NPC.Center.Y, NPCType<LittleBoomxie>());
                }
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.ExplosivePowder, 2, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemType<WillOfTheWisp>(), 20));
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(NPC.Center.X - 10, NPC.Center.Y - 10), 20, 20, DustID.Torch);
                dust.scale = 0.5f;
            }
        }
        public override void OnKill()
        {
            Vector2 zero = new Vector2(0, 0);
<<<<<<< Updated upstream:NPCs/Boomxie/Boomxie.cs
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, zero, ProjectileType<Boom>(), NPC.damage, 0);
=======
            Projectile.NewProjectile(NPC.GetSpawnSourceForNPCFromNPCAI(), NPC.Center, zero, ProjectileType<Boom>(), 30, 0);
>>>>>>> Stashed changes:NewContent/NPCs/Boomxie/Boomxie.cs
        }
    }
    public class LittleBoomxie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boom Dust"); // Automatic from .lang files
            Main.npcFrameCount[NPC.type] = 4; // make sure to set this for your modnpcs.
        }
        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 34;
            NPC.damage = 20;
            NPC.defense = 4;
            NPC.lifeMax = 20;
            NPC.knockBackResist = 1f;
        }
        public override void UpdateLifeRegen(ref int damage)
        {
            NPC.lifeRegen -= 20;
            if (damage < 5)
            {
                damage = 5;
            }
            return;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.ExplosivePowder, 10));
        }
        public override void OnKill()
        {
            Vector2 zero = new Vector2(0, 0);
            if (!Main.expertMode && !Main.masterMode)
            {
<<<<<<< Updated upstream:NPCs/Boomxie/Boomxie.cs
                Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, zero, ProjectileType<Boom>(), NPC.damage, 0);
=======
                Projectile.NewProjectile(NPC.GetSpawnSourceForNPCFromNPCAI(), NPC.Center, zero, ProjectileType<Boom>(), 30, 0);
>>>>>>> Stashed changes:NewContent/NPCs/Boomxie/Boomxie.cs
            }
            else
            {
                NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.Center.X, (int)NPC.Center.Y, NPCID.BurningSphere);
            }
        }
    }
    public class Boom : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.timeLeft = 5;
        }
        public override void AI()
        {
            if (Projectile.timeLeft == 5)
            {
                TRAEMethods.Explode(Projectile, 150, Projectile.damage);
                TRAEMethods.DefaultExplosion(Projectile);
            }
        }
    }

}