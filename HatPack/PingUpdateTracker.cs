using HarmonyLib;
namespace HatPack
{
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingUpdateTracker
    {

        private static string GenerateHatText(HatPackPlugin.AuthorData data)
        {            
            return $"\n{data.HatName} hat by {data.AuthorName}";
        }
        public static void Postfix(PingTracker __instance)
        {

            if (!MeetingHud.Instance)
            {
                __instance.text.text += $"\nHatPack v{HatPackPlugin.Version} created by Om3ga";
                //if (HatPackPlugin.IdToData.ContainsKey(PlayerControl.LocalPlayer.Data.DefaultOutfit.HatId))
                //{
                //    var data = HatPackPlugin.IdToData[PlayerControl.LocalPlayer.Data.DefaultOutfit.HatId];


                //    __instance.text.text += GenerateHatText(data);
                //}
            }
        }
    }
}
