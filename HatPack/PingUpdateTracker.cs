using System.Linq;
using HarmonyLib;
namespace HatPack
{
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingUpdateTracker
    {
        //private static string GenerateHatText(HatPackPlugin.HatData data)
        //{
        //    if (data.name.Contains("vadar"))
        //    {
        //        return
        //            "\n Vadar Hat by Wong";
        //    }
        //    if (data.name.Contains("poly"))
        //    {
        //        return
        //            "\n Polywrath Hat by Wong";
        //    }
        //    if (data.name.Contains("carrot"))
        //    {
        //        return
        //            "\n Carrot Hat by Wong";
        //    }
        //    if (data.name.Contains("raddish"))
        //    {
        //        return
        //            "\n raddish Hat by Wong";
        //    }
        //    if (data.name.Contains("jhin"))
        //    {
        //        return
        //            "\n jhin Hat by Wong";
        //    }
        //    if (data.name.Contains("panda"))
        //    {
        //        return
        //            "\n panda Hat by Wong";
        //    }
        //    if (data.name.Contains("reaper"))
        //    {
        //        return
        //            "\n reaper Hat by Berg";
        //    }
        //    return $"\n{data.name} hat by {data.author}";
        //}
        public static void Postfix(PingTracker __instance)
        {

            if (!MeetingHud.Instance)
            {
                __instance.text.text += "\nHatPack\nv1.5.0\ncreated by Om3ga";                
            }
        }
    }
}
