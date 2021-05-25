using HarmonyLib;
namespace HatPack
{
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingUpdateTracker
    {

        private static string GenerateHatText(HatPackPlugin.AuthorData data)
        {
            if (data.HatName.Contains("vadar"))
            {
                return
                    "\n Vader Hat by Wong";
            }
            if (data.HatName.Contains("poly"))
            {
                return
                    "\n QuirtyXr Hat by Wong";
            }
            if (data.HatName.Contains("carrot"))
            {
                return
                    "\n Carrot Hat by Wong";
            }
            if (data.HatName.Contains("raddish"))
            {
                return
                    "\n Raddish Hat by Wong";
            }
            if (data.HatName.Contains("jhin"))
            {
                return
                    "\n Jhin Hat by Wong";
            }
            if (data.HatName.Contains("panda"))
            {
                return
                    "\n Panda Hat by Wong";
            }
            if (data.HatName.Contains("sourlemon"))
            {
                return
                    "\n Sour Lemon Hat by Wong";
            }
            if (data.HatName.Contains("lofi"))
            {
                return
                    "\n Lofi Hat by Wong";
            }
            if (data.HatName.Contains("rainbowhair"))
            {
                return
                    "\n WillFord Hat by Angel/Wong";
            }
            if (data.HatName.Contains("reaper"))
            {
                return
                    "\n Reaper Hat by Berg";
            }
            return $"\n{data.HatName} hat by {data.AuthorName}";
        }
        public static void Postfix(PingTracker __instance)
        {

            if (!MeetingHud.Instance)
            {
                __instance.text.text += "\nHatPack v1.9.0 created by Om3ga";
                if (HatPackPlugin.IdToData.ContainsKey(PlayerControl.LocalPlayer.Data.HatId))
                {
                    var data = HatPackPlugin.IdToData[PlayerControl.LocalPlayer.Data.HatId];


                    __instance.text.text += GenerateHatText(data);
                }
            }
        }
    }
}
