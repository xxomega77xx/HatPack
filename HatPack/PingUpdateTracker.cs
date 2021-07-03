using HarmonyLib;
namespace HatPack
{
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingUpdateTracker
    {

        private static string GenerateHatText(HatPackPlugin.AuthorData data)
        {
            //if (data.HatName.Contains("birdhead"))
            //{
            //    return
            //        "\n Birdhead Hat by Berg";
            //}
            //if (data.HatName.Contains("blackbirdhead"))
            //{
            //    return
            //        "\n Blackbirdhead Hat by Berg";
            //}
            //if (data.HatName.Contains("jess"))
            //{
            //    return
            //        "\n Jess Hat by Berg";
            //}
            //if (data.HatName.Contains("murderghost"))
            //{
            //    return
            //        "\n murderghost Hat by Berg";
            //}
            //if (data.HatName.Contains("odaidenhat"))
            //{
            //    return
            //        "\n Odaiden Hat by Berg";
            //}
            //if (data.HatName.Contains("Omega"))
            //{
            //    return
            //        "\n Omega Hat by Berg";
            //}
            //if (data.HatName.Contains("reapercostume"))
            //{
            //    return
            //        "\n Reaper Costume Hat by Berg";
            //}
            //if (data.HatName.Contains("reapermask"))
            //{
            //    return
            //        "\n Reaper Mask Hat by Berg";
            //}
            //if (data.HatName.Contains("viking"))
            //{
            //    return
            //        "\n Viking Hat by Berg";
            //}
            //if (data.HatName.Equals("vikingbeer"))
            //{
            //    return
            //        "\n Viking w/ Beer Hat by Berg";
            //}
            return $"\n{data.HatName} hat by {data.AuthorName}";
        }
        public static void Postfix(PingTracker __instance)
        {

            if (!MeetingHud.Instance)
            {
                __instance.text.text += "\nHatPack v2.0.0 created by Om3ga";
                if (HatPackPlugin.IdToData.ContainsKey(PlayerControl.LocalPlayer.Data.HatId))
                {
                    var data = HatPackPlugin.IdToData[PlayerControl.LocalPlayer.Data.HatId];


                    __instance.text.text += GenerateHatText(data);
                }
            }
        }
    }
}
