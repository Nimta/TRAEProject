﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Changes.Weapon.Summon.Minions;
using TRAEProject.Common;

namespace TRAEProject.Common
{
    public class NPCBuffChanges : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public int moths = 0;
        public float braintimer = 0;
        public override void AI(NPC npc)
        {
            if (npc.HasBuff(BuffID.Weak))
            {
                npc.damage = (int)(npc.defDamage * 0.85f);
            }
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            npc.netUpdate = true;
            if (npc.HasBuff(BuffID.CursedInferno))
            {
                npc.lifeRegen -= 48;
                npc.netUpdate = true;
            }
            if (npc.HasBuff(BuffID.ShadowFlame))
            {
                npc.lifeRegen -= 90;
                npc.netUpdate = true;
            }
            if (npc.HasBuff(BuffID.Venom))
            {
                npc.lifeRegen -= 140;
                npc.netUpdate = true;
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (npc.HasBuff(BuffID.Weak))
            {
                drawColor.R = 118;
                drawColor.G = 57;
                drawColor.B = 49;
            }
            if (npc.HasBuff(BuffID.WitheredWeapon))
            {
                if (Main.rand.Next(4) < 1)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width, npc.height, 179, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0.8f;
                    Main.dust[dust].velocity.Y -= 0.3f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
            }
            if (npc.HasBuff(BuffID.WitheredArmor))
            {
                if (Main.rand.Next(5) < 1)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width, npc.height, 21, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 2f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0.8f;
                    Main.dust[dust].velocity.Y -= 0.3f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
            }
        }

    }
    public class NPCBuffChangesG : GlobalBuff
    {
        public override void Update(int type, NPC npc, ref int buffIndex)
        {
            switch (type)
            {
                case BuffID.MaceWhipNPCDebuff:
                    npc.GetGlobalNPC<Tag>().Crit += 10;
                    return;
                case BuffID.RainbowWhipNPCDebuff:
                    npc.GetGlobalNPC<Tag>().Damage += 30;
                    npc.GetGlobalNPC<Tag>().Crit += 20; // this isn't exactly 30% crit but whatevs
                    return;
                case BuffID.ScytheWhipEnemyDebuff:
                    npc.GetGlobalNPC<Tag>().Damage += 10;
                    return;
            }
        }
    }
}
