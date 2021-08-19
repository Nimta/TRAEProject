﻿using System;
using TRAEProject.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;

namespace TRAEProject
{
    public class TRAEMethods
    {
        public static void SpawnProjectilesFromAbove(Terraria.DataStructures.IProjectileSource spawnSource, Vector2 Base, int projectileCount, int spreadX, int spreadY, int[] offsetCenter, float velocity, int type, int damage, float knockback, int player)
        {
            for (int i = 0; i < projectileCount; ++i)
            {
                // where the projectile spawns
                float x2 = Base.X  + Main.rand.Next(-spreadX, spreadX);
                float y = Base.Y - Main.rand.Next((int)(spreadY * 0.8), (int)(spreadY * 1.2));
                ///
                //Calculate Velocity
                Vector2 vector17 = new Vector2(x2, y);
                float X = Base.X - vector17.X;
                float Y = Base.Y + (Main.rand.Next(offsetCenter) * 100) - vector17.Y;
                float squareRoot = (float)Math.Sqrt(X * X + Y * Y);
                squareRoot = velocity / squareRoot;
                X *= squareRoot;
                Y *= squareRoot;
                ///
                // Spawn the projectile
                int Projectile = Terraria.Projectile.NewProjectile(spawnSource, x2, y, X, Y, type, damage, knockback, player);
                // once the projectile reaches the base's position, it will no longer go through tiles.
                Main.projectile[Projectile].localAI[1] += Base.Y;
           
            }
            return;
        }
        public static void Explode(Projectile projectile, int ExplosionRadius, float ExplosionDamage) // Doesn't set any special effects
        {
            projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = false; // without this, the projectile will keep exploding infinitely
            projectile.timeLeft = 3; // Explosion will stay active for 3 frames          
            projectile.alpha = 255; // Projectile becomes invisible
            projectile.damage = (int)(projectile.damage * ExplosionDamage); // Damage is lowered by a certian amount if necessary
            projectile.tileCollide = false; // if set to true, the explosion won't go through blocks (and probably be messed up)
            // Adjust the explosion's hitbox so that it spawns at the center of the projectile.
            projectile.position.X += projectile.width / 2;
            projectile.position.Y += projectile.height / 2;
            projectile.width = projectile.height = ExplosionRadius;
            projectile.position.X -= projectile.width / 2;
            projectile.position.Y -= projectile.height / 2;
            projectile.position.X += projectile.width / 2;
            projectile.position.Y += projectile.height / 2;
            projectile.width = projectile.height = ExplosionRadius;
            projectile.position.X -= (projectile.width / 2);
            projectile.position.Y -= (projectile.height / 2);
        }
        public static void DefaultExplosion(Projectile projectile)
        {
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item14, projectile.position);
            for (int num731 = 0; num731 < 30; ++num731)
            {
                int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
                Dust dust = Main.dust[num732];
                dust.velocity *= 2f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num732].scale = 0.5f;
                    Main.dust[num732].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
                }
            }
            for (int num733 = 0; num733 < 30; ++num733)
            {
                int num734 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
                Main.dust[num734].noGravity = true;
                Dust dust = Main.dust[num734];
                dust.velocity *= 4f;
                num734 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
                dust = Main.dust[num734];
                dust.velocity *= 2f;
            }
        }
    }
}
