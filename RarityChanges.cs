using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace ChangesWeapons
{
    public class ChangesRarity : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.NaturesGift:
                case ItemID.ZombieArm:
                case ItemID.FlinxStaff:
                case ItemID.SauteedFrogLegs:
                    item.rare = ItemRarityID.Blue;
                    return;
                case ItemID.FrogWebbing:
                case ItemID.FrogFlipper:
                case ItemID.AmphibianBoots:
                case ItemID.FalconBlade:
                case ItemID.WrathPotion:
                case ItemID.RagePotion:
                case ItemID.EndurancePotion:
                case ItemID.AmmoReservationPotion:
                case ItemID.HeartreachPotion:
                case ItemID.CalmingPotion:
                case ItemID.SummoningPotion:
                case ItemID.WarmthPotion:
                case ItemID.StinkPotion:
                case ItemID.LovePotion:
                case ItemID.FlaskofFire:
                case ItemID.FlaskofPoison:
                case ItemID.FlaskofParty:
                case ItemID.MulticolorWrench:
                case ItemID.RocketIII:
                case ItemID.ShadowKey:
                case ItemID.ExplosivePowder:
                case ItemID.IllegalGunParts:
                case ItemID.Nanites:
                case ItemID.BoneSword:
                case ItemID.ObsidianHorseshoe:
                case ItemID.PaintSprayer:
                case ItemID.ManaFlower:
                case ItemID.GladiatorBreastplate:
                case ItemID.GladiatorLeggings:
                case ItemID.GladiatorHelmet:
                case ItemID.GingerBeard:
                case ItemID.PoisonStaff:
                case ItemID.RubyHook:
                case ItemID.DiamondHook:
                case ItemID.CloudinaBalloon:
                case ItemID.BlueHorseshoeBalloon:
                case ItemID.BlizzardinaBalloon:
                case ItemID.WhiteHorseshoeBalloon:
                case ItemID.SandstorminaBalloon:
                case ItemID.YellowHorseshoeBalloon:
                case ItemID.BalloonHorseshoeHoney:
                case ItemID.BalloonHorseshoeFart:
                case ItemID.SharkronBalloon:
                case ItemID.BalloonHorseshoeSharkron:
                case ItemID.PygmyNecklace:
                case ItemID.FuzzyCarrot:
                case ItemID.SlimySaddle:
                case ItemID.Flamethrower:
                case ItemID.ThornChakram:
                case ItemID.BladeofGrass:
                case ItemID.JungleYoyo:
                case ItemID.MolluskWhistle:
                case ItemID.DarkHorseSaddle:
                case ItemID.PaintedHorseSaddle:
                case ItemID.MajesticHorseSaddle:
                case ItemID.PogoStick:
                case ItemID.ThornWhip:
                    case ItemID.AnkhCharm:
                    item.rare = ItemRarityID.Green;
                    return;
                case ItemID.AnkhShield:
                case ItemID.PirateMap:
                case ItemID.ObsidianShield:
                case ItemID.ObsidianWaterWalkingBoots:
                case ItemID.ObsidianHelm:
                case ItemID.ObsidianShirt:
                case ItemID.ObsidianPants:
                case ItemID.FrostsparkBoots:
                case ItemID.Beenade:
                case ItemID.LifeforcePotion:
                case ItemID.InfernoPotion:
                case ItemID.TeleportationPotion:
                case ItemID.SittingDucksFishingRod:
                case ItemID.FartInABalloon:
                case ItemID.CobaltBar:
                case ItemID.CobaltOre:
                case ItemID.CobaltChainsaw:
                case ItemID.CobaltWaraxe:
                case ItemID.CobaltPickaxe:
                case ItemID.CobaltDrill:
                case ItemID.CobaltHat:
                case ItemID.CobaltHelmet:
                case ItemID.CobaltMask:
                case ItemID.CobaltBreastplate:
                case ItemID.CobaltLeggings:
                case ItemID.CobaltSword:
                case ItemID.CobaltNaginata:
                case ItemID.CobaltRepeater:
                case ItemID.PalladiumBar:
                case ItemID.PalladiumOre:
                case ItemID.PalladiumChainsaw:
                case ItemID.PalladiumWaraxe:
                case ItemID.PalladiumPickaxe:
                case ItemID.PalladiumDrill:
                case ItemID.PalladiumHelmet:
                case ItemID.PalladiumHeadgear:
                case ItemID.PalladiumMask:
                case ItemID.PalladiumBreastplate:
                case ItemID.PalladiumLeggings:
                case ItemID.PalladiumSword:
                case ItemID.PalladiumPike:
                case ItemID.PalladiumRepeater:
                case ItemID.StingerNecklace:
                case ItemID.LavaFishingHook:
                case ItemID.SuperheatedBlood:
                case ItemID.ObsidianSwordfish:
                    item.rare = ItemRarityID.Orange;
                    return;
                case ItemID.MythrilBar:
                case ItemID.MythrilOre:
                case ItemID.MythrilChainsaw:
                case ItemID.MythrilWaraxe:
                case ItemID.MythrilPickaxe:
                case ItemID.MythrilDrill:
                case ItemID.MythrilHelmet:
                case ItemID.MythrilHat:
                case ItemID.MythrilHood:
                case ItemID.MythrilChainmail:
                case ItemID.MythrilGreaves:
                case ItemID.MythrilSword:
                case ItemID.MythrilHalberd:
                case ItemID.MythrilRepeater:
                case ItemID.OrichalcumBar:
                case ItemID.OrichalcumOre:
                case ItemID.OrichalcumChainsaw:
                case ItemID.OrichalcumWaraxe:
                case ItemID.OrichalcumPickaxe:
                case ItemID.OrichalcumDrill:
                case ItemID.OrichalcumHelmet:
                case ItemID.OrichalcumHeadgear:
                case ItemID.OrichalcumMask:
                case ItemID.OrichalcumBreastplate:
                case ItemID.OrichalcumLeggings:
                case ItemID.OrichalcumSword:
                case ItemID.OrichalcumHalberd:
                case ItemID.OrichalcumRepeater:
                case ItemID.PocketMirror:
                case ItemID.Gradient:
                case ItemID.AngelWings:
                case ItemID.DemonWings:
                case ItemID.LeafWings:
                case ItemID.FrostStaff:
                case ItemID.Frostbrand:
                case ItemID.IceBow:
                case ItemID.PirateMinecart:
                    item.rare = ItemRarityID.LightRed;
                    return;
                case ItemID.HighVelocityBullet:
                case ItemID.VialofVenom:
                case ItemID.LightKey:
                case ItemID.NightKey:
                case ItemID.FlyingKnife:
                case ItemID.DaedalusStormbow:
                case ItemID.IlluminantHook:
                case ItemID.TendonHook:
                case ItemID.WormHook:
                case ItemID.NimbusRod:
                case ItemID.Hammush:
                case ItemID.BundleofBalloons:
                case ItemID.AncientHorn:
                case ItemID.BlessedApple:
                case ItemID.StaticHook:
                case ItemID.Gatligator:
                case ItemID.MedusaHead:
                case ItemID.SkyFracture:
                case ItemID.OnyxBlaster:
                case ItemID.ButchersChainsaw:
                case ItemID.HotlineFishingHook:
                case ItemID.AdamantiteBar:
                case ItemID.AdamantiteOre:
                case ItemID.AdamantiteChainsaw:
                case ItemID.AdamantiteWaraxe:
                case ItemID.AdamantitePickaxe:
                case ItemID.AdamantiteDrill:
                case ItemID.AdamantiteHeadgear:
                case ItemID.AdamantiteHelmet:
                case ItemID.AdamantiteMask:
                case ItemID.AdamantiteBreastplate:
                case ItemID.AdamantiteLeggings:
                case ItemID.AdamantiteSword:
                case ItemID.AdamantiteGlaive:
                case ItemID.AdamantiteRepeater:
                case ItemID.TitaniumBar:
                case ItemID.TitaniumOre:
                case ItemID.TitaniumChainsaw:
                case ItemID.TitaniumWaraxe:
                case ItemID.TitaniumPickaxe:
                case ItemID.TitaniumDrill:
                case ItemID.TitaniumHelmet:
                case ItemID.TitaniumHeadgear:
                case ItemID.TitaniumMask:
                case ItemID.TitaniumBreastplate:
                case ItemID.TitaniumLeggings:
                case ItemID.TitaniumSword:
                case ItemID.TitaniumTrident:
                case ItemID.TitaniumRepeater:
                case ItemID.PrismaticPunch:
                case ItemID.PigronMinecart:
                case ItemID.DiggingMoleMinecart:
                    item.rare = ItemRarityID.Pink;
                    return;
                case ItemID.MonkStaffT1:
                case ItemID.MonkStaffT2:
                case ItemID.BookStaff:
                case ItemID.DD2SquireDemonSword:
                case ItemID.DD2PhoenixBow:
                case ItemID.DD2PetGhost:
                case ItemID.BatWings:
                case ItemID.BeeWings:
                case ItemID.ButterflyWings:
                case ItemID.FlameWings:
                case ItemID.ProximityMineLauncher:
                case ItemID.Megashark:
                case ItemID.LightDisc:
                case ItemID.RainbowRod:
                case ItemID.MagicalHarp:
                case ItemID.OpticStaff:
                case ItemID.Clentaminator:
                case ItemID.AvengerEmblem:
                case ItemID.CelestialEmblem:
                case ItemID.HallowedBar:
                case ItemID.PickaxeAxe:
                case ItemID.Drax:
                case ItemID.Excalibur:
                case ItemID.Gungnir:
                case ItemID.HallowedRepeater:
                case ItemID.HallowedMask:
                case ItemID.HallowedHelmet:
                case ItemID.HallowedHeadgear:
                case ItemID.HallowedPlateMail:
                case ItemID.HallowedGreaves:
                case ItemID.FireworksLauncher:
                case ItemID.QueenSlimeMountSaddle:
                case ItemID.BeetleMinecart:
                case ItemID.SanguineStaff:
                    item.rare = ItemRarityID.LightPurple;
                    return;
                case ItemID.DeadlySphereStaff:
                case ItemID.ToxicFlask:
                case ItemID.TacticalShotgun:
                case ItemID.SpectreStaff:
                case ItemID.ShadowbeamStaff:
                case ItemID.InfernoFork:
                case ItemID.MagnetSphere:
                case ItemID.Keybrand:
                case ItemID.PaladinsHammer:
                case ItemID.PaladinsShield:
                case ItemID.RocketLauncher:
                case ItemID.SniperRifle:
                case ItemID.Kraken:
                case ItemID.MonkBrows:
                case ItemID.MonkShirt:
                case ItemID.MonkPants:
                case ItemID.HuntressWig:
                case ItemID.HuntressJerkin:
                case ItemID.HuntressPants:
                case ItemID.ApprenticeHat:
                case ItemID.ApprenticeRobe:
                case ItemID.ApprenticeTrousers:
                case ItemID.SquireGreatHelm:
                case ItemID.SquirePlating:
                case ItemID.SquireGreaves:
                case ItemID.TrueNightsEdge:
                case ItemID.TrueExcalibur:
                case ItemID.VenomBullet:
                case ItemID.VenomArrow:
                case ItemID.NanoBullet:
                case ItemID.Seedler:
                case ItemID.GrenadeLauncher:
                case ItemID.WaspGun:
                    item.rare = ItemRarityID.Lime;
                    return;
                case ItemID.SuperDartTrap:
                case ItemID.SpearTrap:
                case ItemID.FlameTrap:
                case ItemID.LihzahrdPowerCell:
                case ItemID.BabyGrinchMischiefWhistle:
                case ItemID.GoldenCrate:
                case ItemID.SniperScope:
                case ItemID.DestroyerEmblem:
                case ItemID.ThornHook:
                case ItemID.AntiGravityHook:
                case ItemID.BatHook:
                case ItemID.CandyCaneHook:
                case ItemID.CelestialStone:
                case ItemID.SpookyHook:
                case ItemID.ChristmasHook:
                case ItemID.SpectrePaintbrush:
                case ItemID.SpectrePaintRoller:
                case ItemID.SpectrePaintScraper:
                case ItemID.SpectreBar:
                case ItemID.ShroomiteBar:
                case ItemID.Hoverboard:
                case ItemID.BoneWings:
                case ItemID.BeetleWings:
                case ItemID.SpookyWings:
                case ItemID.TatteredFairyWings:
                case ItemID.FestiveWings:
                case ItemID.SlapHand:
                case ItemID.NorthPole:
                case ItemID.WireKite:
                case ItemID.GoldenFishingRod:
                case ItemID.ClusterRocketI:
                case ItemID.ClusterRocketII:
                case ItemID.MiniNukeI:
                case ItemID.MiniNukeII:
                case ItemID.ReconScope:
                case ItemID.MushroomSpear:
                case ItemID.FrogGear:
                    item.rare = ItemRarityID.Yellow;
                    return;
                case ItemID.BetsyWings:
                case ItemID.FishronWings:
                case ItemID.Tsunami:
                case ItemID.RazorbladeTyphoon:
                case ItemID.BubbleGun:
                case ItemID.Flairon:
                case ItemID.DD2SquireBetsySword:
                case ItemID.DD2BetsyBow:
                case ItemID.MonkStaffT3:
                case ItemID.ApprenticeStaffT3:
                case ItemID.RainbowWhip:
                case ItemID.PiercingStarlight:
                case ItemID.FairyQueenMagicItem:
                case ItemID.FairyQueenRangedItem:
                case ItemID.HuntressAltHead:
                case ItemID.HuntressAltShirt:
                case ItemID.HuntressAltPants:
                case ItemID.MonkAltHead:
                case ItemID.MonkAltShirt:
                case ItemID.MonkAltPants:
                case ItemID.SquireAltHead:
                case ItemID.SquireAltPants:
                case ItemID.SquireAltShirt:
                case ItemID.ApprenticeAltHead:
                case ItemID.ApprenticeAltPants:
                case ItemID.ApprenticeAltShirt:
                case ItemID.ReindeerBells:  
				
				item.rare = ItemRarityID.Cyan;
                    return;
                case ItemID.PortalGun:
                case ItemID.MoonlordArrow:
                case ItemID.MoonlordBullet:
                case ItemID.RodofDiscord:
                case ItemID.DrillContainmentUnit:
                case ItemID.EmpressBlade:
                case ItemID.SparkleGuitar:
                    item.rare = ItemRarityID.Red;
                    return;
            }
            return;
        }
    }
}