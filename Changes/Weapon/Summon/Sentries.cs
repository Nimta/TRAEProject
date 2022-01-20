﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Changes.Projectiles;

namespace TRAEProject.Changes.Weapon.Summon
{
    public class Sentries : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.QueenSpiderStaff:
                    item.damage = 19; // down from 26
                    break;
                case ItemID.RainbowCrystalStaff:
                    item.damage = 30; // down from 150
                    break;
                case ItemID.MoonlordTurretStaff:
                    item.SetNameOverride("Stardust Portal Staff");
                    break;
                
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.MoonlordTurretStaff:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Summons a stardust portal to shoot lasers at your enemies";
                        }
                    }
                    break;
            }
        }
    }
    public class SentryChanges : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Projectile projectile)
        {
            projectile.timeLeft = Projectile.SentryLifeTime * 60;
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            switch (projectile.type)
            {
                case ProjectileID.SpiderEgg:
                case ProjectileID.BabySpider:
                {
                    int findbuffIndex = target.FindBuffIndex(BuffID.Venom);
                    if (findbuffIndex != -1)
                    {
                        target.DelBuff(findbuffIndex);
                    };
                    return;
                }
            }
        }
    }
}
