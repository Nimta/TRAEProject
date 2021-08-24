﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using ReLogic.Content;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes
{
    public class Mana : ModPlayer
    {
        int maxManaOverride = 0;
        int manaOver400 = 0;
        public int overloadedMana = 0;
        public bool celestialCuffsOverload;
        public override void ResetEffects()
        {
            celestialCuffsOverload = false;
        }
        public override void PostUpdateEquips()
        {
            //Main.NewText("PUE: " + Player.statManaMax2);
            maxManaOverride = Player.statManaMax2;
            if(Player.statMana > 400)
            {
                manaOver400 = Player.statMana - 400;
            }
            else
            {
                manaOver400 = 0;
            }
        }
        public override void PostUpdate()
        {
            //Main.NewText("PU: " + Player.statManaMax2);
            Player.statManaMax2 = maxManaOverride;
            Player.statMana += manaOver400;
            if(overloadedMana > Player.statManaMax2 * 2)
            {
                overloadedMana = Player.statManaMax2 * 2;
            }
        }
        int counter = 0;
        public override bool PreItemCheck()
        {
            if(overloadedMana > 0)
            {
                //Main.NewText("Overloaded Mana:" + overloadedMana);
            }
            return base.PreItemCheck();
        }
        public void GiveManaOverloadable(int amount)
        {
            Player.statMana += amount;
            int bonusMana = 0;
            if(Player.statMana > Player.statManaMax2)
            {
                bonusMana += Player.statMana - Player.statManaMax2;
                Player.statMana = Player.statManaMax2;
            }
            if(bonusMana > 0)
            {
                overloadedMana += bonusMana;
                if(bonusMana != amount)
                {
                    Player.ManaEffect(amount - bonusMana);
                }
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y, Player.width, Player.height), Color.Orange, bonusMana);
            }
            else
            {
                Player.ManaEffect(amount);
            }

        }
        public override void SetStaticDefaults()
        {
            IL.Terraria.Player.ItemCheck_PayMana += PayManaHook; //this method is used by most magic weapons
            IL.Terraria.Player.CheckMana_Item_int_bool_bool += CheckManaHook; //this is used by held projectiles like LMG
        }
        private void PayManaHook(ILContext il)
        {
            var c = new ILCursor(il);
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.Emit(OpCodes.Ldarg_2);
            c.EmitDelegate<Func<Player, Item, bool, bool>>((player, item, canUse) =>
            {
                //Main.NewText("Hijacked!");
                
                bool flag = player.altFunctionUse == 2;
                bool flag2 = false;
                int num = (int)((float)item.mana * player.manaCost);
                if (item.type == ItemID.LaserMachinegun)
                {
                    flag2 = true;
                }
                if (item.type == ItemID.BookStaff && flag)
                {
                    num = (int)((float)(item.mana * 2) * player.manaCost);
                }
                if (item.shoot > ProjectileID.None && ProjectileID.Sets.TurretFeature[item.shoot] && flag)
                {
                    flag2 = true;
                }
                if (item.shoot > 0 && ProjectileID.Sets.MinionTargettingFeature[item.shoot] && flag)
                {
                    flag2 = true;
                }
                if (item.type == ItemID.SoulDrain)
                {
                    flag2 = true;
                }
                if (item.type != ItemID.MedusaHead && (!player.spaceGun || (item.type != ItemID.SpaceGun && item.type != 4347 && item.type != 4348)))
                {
                    if (player.statMana + player.GetModPlayer<Mana>().overloadedMana >= num)
                    {
                        if (!flag2)
                        {
                            if(player.GetModPlayer<Mana>().overloadedMana > 0)
                            {
                                int overloadedManaLoss = Math.Min(player.GetModPlayer<Mana>().overloadedMana, num);
                                player.GetModPlayer<Mana>().overloadedMana -= overloadedManaLoss;
                                num -= overloadedManaLoss;
                            }
                            player.statMana -= num;
                        }
                    }
                    else if (player.manaFlower)
                    {
                        player.QuickMana();
                        if (player.statMana >= num)
                        {
                            if (!flag2)
                            {
                                if (player.GetModPlayer<Mana>().overloadedMana > 0)
                                {
                                    int overloadedManaLoss = Math.Min(player.GetModPlayer<Mana>().overloadedMana, num);
                                    player.GetModPlayer<Mana>().overloadedMana -= overloadedManaLoss;
                                    num -= overloadedManaLoss;
                                }
                                player.statMana -= num;
                            }
                        }
                        else
                        {
                            canUse = false;
                        }
                    }
                    else
                    {
                        canUse = false;
                    }
                }
                return canUse;
            });
            //pop the variable at the top of the stack onto the local variable
            c.Emit(OpCodes.Stloc_0);
            //push the local variable onto the stack
            c.Emit(OpCodes.Ldloc_0);
            c.Emit(OpCodes.Ret);
        }
        private void CheckManaHook(ILContext il)
        {
            var c = new ILCursor(il);
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.Emit(OpCodes.Ldarg_2);
            c.Emit(OpCodes.Ldarg_3);
            c.Emit(OpCodes.Ldarg, 4);
            c.EmitDelegate<Func<Player, Item, int, bool, bool, bool>>((player, item, amount, pay, blockQuickMana) =>
            {
                //Main.NewText("Hijacked!");
                if (amount <= -1)
                    amount = player.GetManaCost(item);

                if (player.statMana + player.GetModPlayer<Mana>().overloadedMana >= amount)
                {
                    if (pay)
                    {
                        CombinedHooks.OnConsumeMana(player, item, amount);
                        if (player.GetModPlayer<Mana>().overloadedMana > 0)
                        {
                            int overloadedManaLoss = Math.Min(player.GetModPlayer<Mana>().overloadedMana, amount);
                            player.GetModPlayer<Mana>().overloadedMana -= overloadedManaLoss;
                            amount -= overloadedManaLoss;
                        }
                        player.statMana -= amount;
                    }

                    return true;
                }

                if (blockQuickMana)
                    return false;

                CombinedHooks.OnMissingMana(player, item, amount);
                if (player.statMana < amount && player.manaFlower)
                    player.QuickMana();

                if (player.statMana >= amount)
                {
                    if (pay)
                    {
                        CombinedHooks.OnConsumeMana(player, item, amount);
                        if (player.GetModPlayer<Mana>().overloadedMana > 0)
                        {
                            int overloadedManaLoss = Math.Min(player.GetModPlayer<Mana>().overloadedMana, amount);
                            player.GetModPlayer<Mana>().overloadedMana -= overloadedManaLoss;
                            amount -= overloadedManaLoss;
                        }
                        player.statMana -= amount;
                    }

                    return true;
                }

                return false;
            });
            //pop the variable at the top of the stack onto the local variable
            c.Emit(OpCodes.Stloc_0);
            //push the local variable onto the stack
            c.Emit(OpCodes.Ldloc_0);
            c.Emit(OpCodes.Ret);
        }
    }
    public class DisplayOverload : ModSystem
    {
        const int OManaPerStar = 40;
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            LegacyGameInterfaceLayer overloadManaDraw = new LegacyGameInterfaceLayer("OverloadedMana",
                    delegate
                    {
                        if(Main.ActivePlayerResourcesSet is ClassicPlayerResourcesDisplaySet)
                        {
                            DrawClassicMana();
                        }
                        if (Main.ActivePlayerResourcesSet is FancyClassicPlayerResourcesDisplaySet)
                        {
                            DrawFancyClassicMana();
                        }
                        if(Main.ActivePlayerResourcesSet is HorizontalBarsPlayerReosurcesDisplaySet)
                        {
                            DrawManaBar();
                        }
                        return true;
                    },
                    InterfaceScaleType.UI);
            layers.Insert(index+1, overloadManaDraw);
        }
        void DrawClassicMana()
        {
            Player localPlayer = Main.LocalPlayer;
            SpriteBatch spriteBatch = Main.spriteBatch;
            Color color = new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor);
            int UIDisplay_ManaPerStar = OManaPerStar;
            int UI_ScreenAnchorX = Main.screenWidth - 800;
            if (localPlayer.ghost || localPlayer.statManaMax2 <= 0)
            {
                return;
            }
            for (int i = 1; i < (localPlayer.statManaMax2 * 2) / UIDisplay_ManaPerStar + 1; i++)
            {
                int num2 = 255;
                bool flag = false;
                float num3 = 1f;
                if (localPlayer.GetModPlayer<Mana>().overloadedMana >= i * UIDisplay_ManaPerStar)
                {
                    num2 = 255;
                    if (localPlayer.GetModPlayer<Mana>().overloadedMana == i * UIDisplay_ManaPerStar)
                    {
                        flag = true;
                    }
                }
                else
                {
                    float num4 = (float)(localPlayer.GetModPlayer<Mana>().overloadedMana - (i - 1) * UIDisplay_ManaPerStar) / (float)UIDisplay_ManaPerStar;
                    num2 = (int)(30f + 225f * num4);
                    if (num2 < 30)
                    {
                        num2 = 0;
                    }
                    num3 = num4 / 4f + 0.75f;
                    if ((double)num3 < 0.75)
                    {
                        num3 = 0.75f;
                    }
                    if (num4 > 0f)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    num3 += Main.cursorScale - 1f;
                }
                int a = (int)((double)num2 * 0.9);
                spriteBatch.Draw(Request<Texture2D>("TRAEProject/Changes/OMana").Value, new Vector2(775 + UI_ScreenAnchorX, (float)(30 + TextureAssets.Mana.Height() / 2) + ((float)TextureAssets.Mana.Height() - (float)TextureAssets.Mana.Height() * num3) / 2f + (float)(28 * (i - 1))), new Rectangle(0, 0, TextureAssets.Mana.Width(), TextureAssets.Mana.Height()), new Color(num2, num2, num2, a), 0f, new Vector2(TextureAssets.Mana.Width() / 2, TextureAssets.Mana.Height() / 2), num3, SpriteEffects.None, 0f);
            }
        }
        void DrawFancyClassicMana()
        {
            Player localPlayer = Main.LocalPlayer;
            int manaPerStar = OManaPerStar;
            int _starCount = (int)((float)(localPlayer.statManaMax2*2) / manaPerStar);


            SpriteBatch spriteBatch = Main.spriteBatch;
            Vector2 vector = new Vector2(Main.screenWidth - 40, 22f);
            bool isHovered = false;
            ResourceDrawSettings resourceDrawSettings = default(ResourceDrawSettings);
            resourceDrawSettings.ElementCount = _starCount;
            resourceDrawSettings.ElementIndexOffset = 0;
            resourceDrawSettings.TopLeftAnchor = vector + new Vector2(15f, 16f);
            resourceDrawSettings.GetTextureMethod = StarFillingDrawer;
            resourceDrawSettings.OffsetPerDraw = Vector2.UnitY * -2f;
            resourceDrawSettings.OffsetPerDrawByTexturePercentile = Vector2.UnitY;
            resourceDrawSettings.OffsetSpriteAnchor = Vector2.Zero;
            resourceDrawSettings.OffsetSpriteAnchorByTexturePercentile = new Vector2(0.5f, 0.5f);
            resourceDrawSettings.Draw(spriteBatch, ref isHovered);
        }
        void StarFillingDrawer(int elementIndex, int firstElementIndex, int lastElementIndex, out Asset<Texture2D> sprite, out Vector2 offset, out float drawScale, out Rectangle? sourceRect)
        {

            Player localPlayer = Main.LocalPlayer;
            int _lastStarFillingIndex = (int)(localPlayer.GetModPlayer<Mana>().overloadedMana / 40f);
            sourceRect = null;
            offset = Vector2.Zero;
            sprite = Request<Texture2D>("TRAEProject/Changes/OManaFancy");
            float num = (drawScale = Utils.GetLerpValue(OManaPerStar * (float)elementIndex, OManaPerStar * (float)(elementIndex + 1), localPlayer.GetModPlayer<Mana>().overloadedMana, clamped: true));
            if (elementIndex == _lastStarFillingIndex && num > 0f)
            {
                drawScale += Main.cursorScale - 1f;
            }
        }
        void DrawManaBar()
        {
            
            int num = 16;
            int num2 = 18;
            int num3 = Main.screenWidth - 300 - 22 + num;
            Player localPlayer = Main.LocalPlayer;
            int manaPerStar = OManaPerStar;
            int _mpSegmentsCount = (int)((float)(localPlayer.statManaMax2 * 2) / manaPerStar);
            Vector2 vector2 = new Vector2(num3 - 10, num2 + 24);
            vector2.X += (400 - _mpSegmentsCount) * 12;
            SpriteBatch spriteBatch = Main.spriteBatch;
            bool isHovered = false;

           

            ResourceDrawSettings resourceDrawSettings = default(ResourceDrawSettings);
            resourceDrawSettings.ElementCount = _mpSegmentsCount;
            resourceDrawSettings.ElementIndexOffset = 0;
            resourceDrawSettings.TopLeftAnchor = vector2 + new Vector2(6f, 6f);
            resourceDrawSettings.GetTextureMethod = ManaFillingDrawer;
            resourceDrawSettings.OffsetPerDraw = new Vector2(12, 0f);
            resourceDrawSettings.OffsetPerDrawByTexturePercentile = Vector2.Zero;
            resourceDrawSettings.OffsetSpriteAnchor = Vector2.Zero;
            resourceDrawSettings.OffsetSpriteAnchorByTexturePercentile = Vector2.Zero;
            resourceDrawSettings.Draw(spriteBatch, ref isHovered);
        }
        private static void FillBarByValues(int elementIndex, Asset<Texture2D> sprite, int segmentsCount, float fillPercent, out Vector2 offset, out float drawScale, out Rectangle? sourceRect)
        {
            sourceRect = null;
            offset = Vector2.Zero;
            float num = 1f;
            float num2 = 1f / (float)segmentsCount;
            float t = 1f - fillPercent;
            float lerpValue = Utils.GetLerpValue(num2 * (float)elementIndex, num2 * (float)(elementIndex + 1), t, clamped: true);
            num = 1f - lerpValue;
            drawScale = 1f;
            Rectangle value = sprite.Frame();
            int num3 = (int)((float)value.Width * (1f - num));
            offset.X += num3;
            value.X += num3;
            value.Width -= num3;
            sourceRect = value;
        }

        private void ManaFillingDrawer(int elementIndex, int firstElementIndex, int lastElementIndex, out Asset<Texture2D> sprite, out Vector2 offset, out float drawScale, out Rectangle? sourceRect)
        {

            
            Player localPlayer = Main.LocalPlayer;
            int manaPerStar = OManaPerStar;
            int _mpSegmentsCount = (int)((float)(localPlayer.statManaMax2 * 2) / manaPerStar);
            float _mpPercent = (float)localPlayer.GetModPlayer<Mana>().overloadedMana / (float)(localPlayer.statManaMax2 * 2);
            sprite = Request<Texture2D>("TRAEProject/Changes/OMPFill");
            FillBarByValues(elementIndex, sprite, _mpSegmentsCount, _mpPercent, out offset, out drawScale, out sourceRect);
        }
    }
}
