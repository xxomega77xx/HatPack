using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;
using System.Collections.Generic;
using UnityEngine;
//code examples borrowed from townofus creators if it aint broke don't fix it LOL
namespace HatPack
{
    [BepInPlugin(Id , "HatPack", "2.0.1")]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public class HatPackPlugin : BasePlugin
    {

        public const string Id = "hats.pack";

        public Harmony Harmony { get; } = new Harmony(Id);

        public override void Load()
        {
            Assets.LoadAssetBundle();
            Harmony.PatchAll();
        }

        protected internal struct AuthorData
        {
            public string AuthorName;
            public string HatName;
            public string FloorHatName;
            public string ClimbHatName;
            public bool bounce;
        }
        //Be sure to spell everything right or it will not load all hats after spelling error
        //Must be prefab name not name of asset for hatname
        private static List<AuthorData> authorDatas = new List<AuthorData>()
        {
            new AuthorData {AuthorName = "Berg", HatName = "birdhead", bounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "blackbirdhead", bounce = false },
            new AuthorData {AuthorName = "Angel", HatName = "jess", bounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "murderghost" , bounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "odaidenhat", bounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "Omega", bounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "reapercostume", bounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "reapermask", bounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "viking", bounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "vikingbeer", bounce = false}
        };

        internal static Dictionary<uint, AuthorData> IdToData = new Dictionary<uint, AuthorData>();

        private static bool _customHatsLoaded = false;
        [HarmonyPatch(typeof(HatManager), nameof(HatManager.GetHatById))]
        public static class AddCustomHats
        {
            public static void Prefix(PlayerControl __instance)
            {
                if (!_customHatsLoaded)
                {
                    var allHats = HatManager.Instance.AllHats;

                    foreach (var data in authorDatas)
                    {
                        HatID++;
                        if (data.FloorHatName != null && data.ClimbHatName != null)
                        {
                            System.Console.WriteLine($"Adding {data.HatName} and associated floor/climb hats");
                            if (data.bounce)
                            {
                                System.Console.WriteLine($"Adding {data.HatName} with bounce enabled");
                                allHats.Add(CreateHat(GetSprite(data.HatName), GetSprite(data.ClimbHatName), GetSprite(data.FloorHatName), true));
                            }
                            else
                            {
                                System.Console.WriteLine($"Adding {data.HatName} with bounce disabled");
                                allHats.Add(CreateHat(GetSprite(data.HatName), GetSprite(data.ClimbHatName), GetSprite(data.FloorHatName)));
                            }

                        }
                        else
                        {
                            System.Console.WriteLine($"Adding {data.HatName}");
                            allHats.Add(CreateHat(GetSprite(data.HatName)));
                        }
                        IdToData.Add((uint)HatManager.Instance.AllHats.Count - 1, data);

                        _customHatsLoaded = true;
                    }



                    _customHatsLoaded = true;
                }
            }

            private static Sprite GetSprite(string name)
                => Assets.LoadAsset(name).Cast<GameObject>().GetComponent<SpriteRenderer>().sprite;

            private static int HatID = 0;

            private static HatBehaviour CreateHat(Sprite sprite, Sprite climb = null, Sprite floor = null, bool bounce = false)
            {
                var newHat = ScriptableObject.CreateInstance<HatBehaviour>();
                newHat.MainImage = sprite;
                newHat.ProductId = $"hat_{sprite.name}";
                newHat.Order = 199 + HatID;
                newHat.InFront = true;
                newHat.NoBounce = bounce;
                newHat.FloorImage = floor;
                newHat.ClimbImage = climb;
                newHat.ChipOffset = new Vector2(-0.1f, 0.4f);

                return newHat;
            }
        }

    }
}
