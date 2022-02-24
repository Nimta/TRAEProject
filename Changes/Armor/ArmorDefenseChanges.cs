
using TRAEProject.NewContent.Buffs;
using TRAEProject.NewContent.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace TRAEProject.Changes.Armor
{
    public class DefenseChanges : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.PharaohsMask:
                    item.defense = 2;
                    item.vanity = false;
                    break;
                case ItemID.PharaohsRobe:
                    item.defense = 3;
                    item.vanity = false;
                    break;
          
                case ItemID.RuneHat:
                    item.defense = 4;
                    item.vanity = false;
                    break;
                case ItemID.GladiatorHelmet:
                case ItemID.GladiatorLeggings:
                    item.defense = 6;
                    break;
                case ItemID.RuneRobe:
                case ItemID.GladiatorBreastplate:
                    item.defense = 8;
                    item.vanity = false;
                    break;
                case ItemID.PirateHat:
                    item.defense = 7;
                    item.rare = ItemRarityID.Orange;
                    item.vanity = false;
                    break;
                case ItemID.PirateShirt:
                    item.defense = 12;
                    item.rare = ItemRarityID.Orange;
                    item.vanity = false;
                    break;
                case ItemID.PiratePants:
                    item.defense = 9;
                    item.rare = ItemRarityID.Orange;
                    item.vanity = false;
                    break;

                case ItemID.WoodGreaves:
                    item.defense = 1;
                    break;
                case ItemID.BorealWoodBreastplate:
                case ItemID.PalmWoodBreastplate:
                case ItemID.EbonwoodHelmet:
                case ItemID.EbonwoodGreaves:
                case ItemID.ShadewoodHelmet:
                case ItemID.ShadewoodGreaves:
                case ItemID.RichMahoganyHelmet:
                case ItemID.RichMahoganyBreastplate:
                case ItemID.RichMahoganyGreaves:
                    item.defense = 2;
                    break;
                case ItemID.CopperHelmet:
                case ItemID.CopperGreaves:
                case ItemID.TinGreaves:
                    item.defense = 3;
                    break;
                case ItemID.CopperChainmail:
                case ItemID.TinHelmet:
                case ItemID.TinChainmail:
                case ItemID.IronHelmet:
                case ItemID.AncientIronHelmet:
                case ItemID.IronGreaves:
                case ItemID.LeadGreaves:
                    item.defense = 4;
                    break;
                case ItemID.IronChainmail:
                case ItemID.LeadChainmail:
                case ItemID.LeadHelmet:
                case ItemID.SilverGreaves:
                case ItemID.TungstenGreaves:
                case ItemID.SilverHelmet:
                case ItemID.FossilHelm:
                case ItemID.FossilPants:
                    item.defense = 5;
                    break;
                case ItemID.JungleHat:
                case ItemID.TungstenHelmet:
                case ItemID.TungstenChainmail:
                case ItemID.SilverChainmail:
                case ItemID.GoldHelmet:
                case ItemID.GoldGreaves:
                case ItemID.AncientGoldHelmet:
                case ItemID.PlatinumGreaves:
                case ItemID.FossilShirt:
                    item.defense = 6;
                    break;
                case ItemID.MythrilHat:
                case ItemID.GoldChainmail:
                case ItemID.PlatinumChainmail:
                case ItemID.PlatinumHelmet:
                case ItemID.ShadowHelmet:
                case ItemID.CrimsonHelmet:
                case ItemID.AncientShadowHelmet:
                case ItemID.ShadowGreaves:
                case ItemID.CrimsonGreaves:
                case ItemID.AncientShadowGreaves:
                    item.defense = 7;
                    break;
                case ItemID.ChlorophyteGreaves:
                    item.defense = 8;
                    break;
                case ItemID.FleshKnuckles:
                case ItemID.BerserkerGlove:
                    item.defense = 10;
                    break;
                case ItemID.ChlorophytePlateMail:
                    item.defense = 13;
                    break;   
                case ItemID.AncientArmorHat:
                    item.defense = 13;
                    item.vanity = false;
                    break;
                case ItemID.AncientArmorShirt:
                    item.defense = 8;
                    item.vanity = false;
                    break;
                case ItemID.AncientArmorPants:
                    item.defense = 7;
                    item.vanity = false;
                    break;
                case ItemID.DjinnsCurse:
                    item.defense = 12;
                    item.vanity = false;
                    break;
                case ItemID.SpectreMask:
                case ItemID.SpectreHood:
                    item.defense = 12;
                    break;

            }
        }      
    }
}
