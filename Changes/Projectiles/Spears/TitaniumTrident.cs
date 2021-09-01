﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TRAEProject.Common;

namespace TRAEProject.Changes.Projectiles.Spears
{
    public class TitaniumTrident : Spear
    {
        public override void SpearDefaults()
        {
            spearLength = 155.5f;
            stabStart = 124.5f;
            stabEnd = -10;
            swingAmount = (float)Math.PI / 32;
        }
    }
    public class TitaniumTridentThrow : SpearThrow
    {
        public override void SpearDefaults()
        {
            spearLength = 155.5f;
            holdAt = 93f;
            Projectile.ignoreWater = true;
            maxSticks = 5;
            stickingDps = 30;
            floatTime = 60;
        }
    }
}
