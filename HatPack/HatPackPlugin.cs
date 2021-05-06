using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;
using System.Linq;
using UnityEngine;

namespace HatPack
{
    [BepInPlugin(Id , "HatPack", "1.0.0.0")]
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
                //FileLog.logPath = @"C:\AmongUsModded\BepInEx\ModLogs\BunkerLog.log";
                if (!_customHatsLoaded)
                {
                    var allHats = HatManager.Instance.AllHats;

                    var customHatNames = new[] { "panda", "carrot", "raddish", "reaper" };
                    string[] climbHatNames = { "reaper.climb" };
                    string[] floorHatNames = { "reaper.dead" };
                    //FileLog.Log($"Number of hats : { customHatNames.Length}");
                    
                    foreach (string hatName in customHatNames)
                    {
                        HatID++;
                        if (floorHatNames.Contains($"{hatName}.dead") && climbHatNames.Contains($"{hatName}.climb"))
                        {
                            string floorHat = $"{hatName}.dead";
                            string climbHat = $"{hatName}.climb";

                            //FileLog.Log($"Climbhat : {climbHat}");
                            //FileLog.Log($"Floorhat : {floorHat}");
                            //FileLog.Log($"Creating : {hatName}");
                            allHats.Add(CreateHat(GetSprite(hatName), GetSprite(climbHat), GetSprite(floorHat)));
                            //FileLog.Log($"Hat Created : {hatName}");
                        }
                        else
                        {
                            //FileLog.Log($"Creating : {hatName}");
                            allHats.Add(CreateHat(GetSprite(hatName)));
                            //FileLog.Log($"Hat Created : {hatName}");
                        }

                        
                        _customHatsLoaded = true;
                    }

                    

                    _customHatsLoaded = true;
                    //FileLog.Log($"CustomHats Loaded : {_customHatsLoaded}");
                }
            }

            private static Sprite GetSprite(string name)
                => Assets.LoadAsset(name).Cast<GameObject>().GetComponent<SpriteRenderer>().sprite;

            private static int HatID = 0;

            private static HatBehaviour CreateHat(Sprite sprite, Sprite climb = null, Sprite floor = null)
            {                

                return new HatBehaviour
                {
                    MainImage = sprite,
                    ProductId = $"hat_{sprite.name}",
                    InFront = true,
                    NoBounce = true,
                    Order = 99 + HatID,
                    ClimbImage = climb,
                    FloorImage = floor
                };
            }
        }

    }
}
