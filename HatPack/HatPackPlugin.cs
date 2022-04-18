using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using BepInEx.Logging;
using System.Collections.Generic;
using UnityEngine;
//code examples borrowed from townofus creators if it aint broke don't fix it LOL
namespace HatPack
{
    [BepInPlugin(Id, "HatPack", Version)]
    [BepInProcess("Among Us.exe")]
    public class HatPackPlugin : BasePlugin
    {

        public static Material MagicShader;
        public const string Version = "4.0.2";

        public const string Id = "hats.pack";

        public Harmony Harmony { get; } = new Harmony(Id);

        public override void Load()
        {
            Assets.LoadAssetBundle();
            Harmony.PatchAll();
        }

        public struct AuthorData
        {
            public string AuthorName;
            public string HatName;
            public string FloorHatName;
            public string ClimbHatName;
            public string LeftImageName;
            public bool NoBounce;
            public bool altShader;
        }
        //Be sure to spell everything right or it will not load all hats after spelling error
        //Must be prefab name not name of asset for hatname
        public static List<AuthorData> authorDatas = new List<AuthorData>()
        {
            new AuthorData {AuthorName = "Berg", HatName = "birdhead", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "Army", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "Navy", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "Marine", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "Airforce", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "a_pretty_sus", LeftImageName = "a_pretty_sus_left", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "ParadoxMonkey", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "Gina", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "imsus", LeftImageName = "imsus_left", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "blackbirdhead", NoBounce = false },
            new AuthorData {AuthorName = "Angel", HatName = "jess", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "murderghost" , NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "odaidenhat", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "Omega", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "reapercostume",FloorHatName ="reaperdead",ClimbHatName = "reaperclimb",LeftImageName = "reapercostumeleft", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "reapermask",FloorHatName ="reaperdead",ClimbHatName = "reaperclimb",LeftImageName = "reapermaskleft", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "viking", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "vikingbeer", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "pineapple", NoBounce = false},
            //new AuthorData {AuthorName = "Berg", HatName = "willhair", NoBounce = false},
            new AuthorData {AuthorName = "Wong", HatName = "vader",FloorHatName ="vaderdead",ClimbHatName = "vaderclimb", NoBounce = false},
            new AuthorData {AuthorName = "Berg", HatName = "unclesam",FloorHatName ="unclesamdead", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Bunpix", NoBounce = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Cadbury", NoBounce = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "CatEars", NoBounce = true,altShader = true},
            new AuthorData {AuthorName = "Angel", HatName = "dirtybirb", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "DJ", NoBounce = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "EnbyScarf", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Happy", NoBounce = false, altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Carla", NoBounce = false, altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Pika", NoBounce = false, altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Gun", NoBounce = false, altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Espeon", NoBounce = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Gwendolyn", NoBounce = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Jester", NoBounce = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "PizzaRod", NoBounce = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Sombra", NoBounce = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Sprxk", NoBounce = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Swole", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "TransScarf", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Unicorn", NoBounce = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Wings", NoBounce = false},
            new AuthorData {AuthorName = "Paradox", HatName = "Dino", NoBounce = true, altShader=true},
            new AuthorData {AuthorName = "Berg", HatName = "Ugg", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "SilverSylveon", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "DownyCrake", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Ram", NoBounce = false , altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Kitsune", NoBounce = true, altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "GlitchedSwole", NoBounce = true, altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "TigerShark", NoBounce = true, altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Eevee_Female", NoBounce = false,altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Eevee_Male", NoBounce = false,altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Crowned_Bluebelle", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Bluebow", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "Boneskinner", NoBounce = false},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "DjDolphin", NoBounce = false,altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "OzzaMask", NoBounce = false,altShader = true},
            new AuthorData {AuthorName = "NightRaiderTea", HatName = "HornsofDevils", NoBounce = false}
        };

        internal static Dictionary<int, AuthorData> IdToData = new Dictionary<int, AuthorData>();

        private static bool _customHatsLoaded = false;
        [HarmonyPatch(typeof(HatManager), nameof(HatManager.GetHatById))]
        public static class AddCustomHats
        {

            public static void Prefix(HatManager __instance)
            {
                var CHLog = new ManualLogSource("HatPack");
                BepInEx.Logging.Logger.Sources.Add(CHLog);
                if (!_customHatsLoaded)
                {
                    var allHats = DestroyableSingleton<HatManager>.Instance.allHats;

                    foreach (var data in authorDatas)
                    {
                        HatID++;

                        if (data.FloorHatName != null && data.ClimbHatName != null && data.LeftImageName != null)
                        {
                            //CHLog.LogInfo($"Adding {data.HatName} and associated floor/climb hats/left image");
                            if (data.NoBounce)
                            {
                                if (data.altShader == true)
                                {
                                    //CHLog.LogInfo("Adding {0} with Alt shaders and bounce",data.HatName);
                                    __instance.allHats.Add(CreateHat(GetSprite(data.HatName), data.AuthorName, GetSprite(data.ClimbHatName), GetSprite(data.FloorHatName), null, true, true));
                                }
                                else
                                {
                                    //CHLog.LogInfo($"Adding {data.HatName} with bounce enabled");
                                    allHats.Add(CreateHat(GetSprite(data.HatName), data.AuthorName, GetSprite(data.ClimbHatName), GetSprite(data.FloorHatName), GetSprite(data.LeftImageName), true, false));
                                }
                            }
                            else
                            {
                                //CHLog.LogInfo($"Adding {data.HatName} with bounce disabled");
                                allHats.Add(CreateHat(GetSprite(data.HatName), data.AuthorName, GetSprite(data.ClimbHatName), GetSprite(data.FloorHatName), GetSprite(data.LeftImageName)));
                            }

                        }
                        else
                        {
                            if (data.altShader == true)
                            {
                                //CHLog.LogInfo($"Adding {data.HatName} with Alt shaders");
                                allHats.Add(CreateHat(GetSprite(data.HatName), data.AuthorName, null, null, null, false, true));
                            }
                            else
                            {
                                //CHLog.LogInfo($"Adding {data.HatName}");
                                allHats.Add(CreateHat(GetSprite(data.HatName), data.AuthorName));
                            }
                        }
                        IdToData.Add(HatManager.Instance.allHats.Count - 1, data);

                        _customHatsLoaded = true;
                    }



                    _customHatsLoaded = true;
                }
            }

            public static Sprite GetSprite(string name)
                => Assets.LoadAsset(name).Cast<GameObject>().GetComponent<SpriteRenderer>().sprite;

            public static int HatID = 0;
            /// <summary>
            /// Creates hat based on specified values
            /// </summary>
            /// <param name="sprite"></param>
            /// <param name="author"></param>
            /// <param name="climb"></param>
            /// <param name="floor"></param>
            /// <param name="leftimage"></param>
            /// <param name="bounce"></param>
            /// <param name="altshader"></param>
            /// <returns>HatBehaviour</returns>
            private static HatData CreateHat(Sprite sprite, string author, Sprite climb = null, Sprite floor = null, Sprite leftimage = null, bool bounce = false, bool altshader = false)
            {
                //Borrowed from Other Roles to get hats alt shaders to work
                if(MagicShader == null) {
                    Material tmpShader = new Material("PlayerMaterial");
                    tmpShader.shader = Shader.Find("Unlit/PlayerShader");
                    MagicShader = tmpShader;
                }
                var newHat = ScriptableObject.CreateInstance<HatData>();
                newHat.name = $"{sprite.name} by {author}";
                newHat.hatViewData.viewData = ScriptableObject.CreateInstance<HatViewData>();
                newHat.hatViewData.viewData.MainImage = sprite;
                newHat.StoreName = "HatPack";
                newHat.ProductId = "hat_" + sprite.name.Replace(' ', '_');
                newHat.displayOrder = 99 + HatID;
                newHat.InFront = true;
                newHat.NoBounce = bounce;
                newHat.hatViewData.viewData.FloorImage = floor;
                newHat.hatViewData.viewData.ClimbImage = climb;
                newHat.Free = true;
                newHat.hatViewData.viewData.LeftMainImage = leftimage;
                newHat.ChipOffset = new Vector2(-0.1f, 0.4f);
                if (altshader == true){ newHat.hatViewData.viewData.AltShader = MagicShader; }

                return newHat;
            }
        }
    }
}
