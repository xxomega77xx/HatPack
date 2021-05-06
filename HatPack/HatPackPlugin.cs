using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;
using System.Linq;
using UnityEngine;

namespace HatPack
{
    [BepInPlugin(Id , "HatPack", "1.3.0")]
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
        private static bool _customHatsLoaded = false;        
        [HarmonyPatch(typeof(HatManager), nameof(HatManager.GetHatById))]
        public static class AddCustomHats
        {
            public static void Prefix(PlayerControl __instance)
            {
                if (!_customHatsLoaded)
                {
                    var allHats = HatManager.Instance.AllHats;

                    var customHatNames = new[] { "panda", "carrot", "raddish", "reaper" };
                    string[] climbHatNames = { "reaper.climb" };
                    string[] floorHatNames = { "reaper.dead" };
                    
                    foreach (string hatName in customHatNames)
                    {
                        HatID++;
                        if (floorHatNames.Contains($"{hatName}.dead") && climbHatNames.Contains($"{hatName}.climb"))
                        {
                            string floorHat = $"{hatName}.dead";
                            string climbHat = $"{hatName}.climb";
                            allHats.Add(CreateHat(GetSprite(hatName), GetSprite(climbHat), GetSprite(floorHat)));
                        }
                        else
                        {
                            allHats.Add(CreateHat(GetSprite(hatName)));
                        }

                        
                        _customHatsLoaded = true;
                    }

                    

                    _customHatsLoaded = true;
                }
            }

            private static Sprite GetSprite(string name)
                => Assets.LoadAsset(name).Cast<GameObject>().GetComponent<SpriteRenderer>().sprite;

            private static int HatID = 0;

            private static HatBehaviour CreateHat(Sprite sprite, Sprite climb = null, Sprite floor = null)
            {
                var newHat = ScriptableObject.CreateInstance<HatBehaviour>();
                newHat.MainImage = sprite;
                newHat.ProductId = $"hat_{sprite.name}";
                newHat.Order = 99 + HatID;
                newHat.InFront = true;
                newHat.NoBounce = true;
                newHat.FloorImage = floor;
                newHat.ClimbImage = climb;

                return newHat;
            }
        }

    }
}
