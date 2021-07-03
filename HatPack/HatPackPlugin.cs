using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;
using System.Collections.Generic;
using UnityEngine;
//code examples borrowed from townofus creators
namespace HatPack
{
    [BepInPlugin(Id , "HatPack", "1.9.0")]
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
        private static List<AuthorData> authorDatas = new List<AuthorData>()
        {
            new AuthorData {AuthorName = "Wong", HatName = "vadar",FloorHatName = "vadar.dead", ClimbHatName = "vadar.climb", bounce = true},
            new AuthorData {AuthorName = "Wong", HatName = "panda", bounce = false },
            new AuthorData {AuthorName = "Wong", HatName = "carrot", bounce = false},
            new AuthorData {AuthorName = "Wong", HatName = "raddish" , bounce = false},
            new AuthorData {AuthorName = "Wong", HatName = "jhin",FloorHatName = "jhin.dead", ClimbHatName = "jhin.climb", bounce = false},
            new AuthorData {AuthorName = "Wong", HatName = "poly",FloorHatName = "poly.dead", ClimbHatName = "poly.climb", bounce = true},
            new AuthorData {AuthorName = "Wong", HatName = "sourlemon",ClimbHatName="sourlemon.climb", bounce = false},
            new AuthorData {AuthorName = "Wong", HatName = "lofi",ClimbHatName="lofi.climb", bounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "reaper",FloorHatName = "reaper.dead", ClimbHatName = "reaper.climb", bounce = false},
            new AuthorData {AuthorName = "Angel/Wong", HatName = "rainbowhair", ClimbHatName = "rainbowhair.climb", bounce = false}
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
