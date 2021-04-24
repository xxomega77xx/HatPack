using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Reactor.Extensions;
using UnityEngine;

namespace HatPack
{
    public class Assets
    {
        private static AssetBundle AssetBundle;

        public static void LoadAssetBundle()
        {
            //FileLog.logPath = @"C:\AmongUsModded\BepInEx\ModLogs\BunkerLog.log";
            //FileLog.Log("Loading Asset Bundle");
            byte[] bundleRead = Assembly.GetCallingAssembly().GetManifestResourceStream("HatPack.HatPackAssets.assetbundle").ReadFully();
            AssetBundle = AssetBundle.LoadFromMemory(bundleRead);
            //FileLog.Log("Asset Bundle Loaded");

        }

        public static UnityEngine.Object LoadAsset(string name)
            => AssetBundle.LoadAsset(name);
    }
}

