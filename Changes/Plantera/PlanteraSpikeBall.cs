﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Plantera
{
    class PlanteraSpikeBall : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            if(projectile.type == ProjectileID.ThornBall)
            {
                projectile.alpha = 0;
                projectile.scale = 1.5f;
            }
        }
        public override bool PreAI(Projectile projectile)
        {
            if (projectile.type == ProjectileID.ThornBall && projectile.ai[1] == 0)
            {
                //Main.NewText(projectile.ai[0] + ", " + projectile.ai[1] + ", " + projectile.localAI[0] + ", " + projectile.localAI[1]);
                return false;
            }
            return base.PreAI(projectile);
        }
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            
            if (projectile.type == ProjectileID.ThornBall)
            {
                if (projectile.ai[1] == 0)
                {
                    if (projectile.velocity.X != oldVelocity.X)
                    {
                        projectile.velocity.X = -oldVelocity.X;
                    }
                    if (projectile.velocity.Y != oldVelocity.Y)
                    {
                        projectile.velocity.Y = -oldVelocity.Y;
                    }
                }
                projectile.localAI[0] = 1;
            }
            return base.OnTileCollide(projectile, oldVelocity);
        }
        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            if (projectile.type == ProjectileID.ThornBall)
            {
                Texture2D texture = TextureAssets.Projectile[projectile.type].Value;
                Main.EntitySpriteDraw(texture, projectile.Center - Main.screenPosition,
                            null, lightColor, projectile.rotation,
                            new Vector2(texture.Width * 0.5f, texture.Height * 0.5f), projectile.scale, SpriteEffects.None, 0);
                return false;
            }
            return base.PreDraw(projectile, ref lightColor);
        }
    }
}
