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
            byte[] bundleRead = Assembly.GetCallingAssembly().GetManifestResourceStream("HatPack.HatPackAssets.assetbundle").ReadFully();
            AssetBundle = AssetBundle.LoadFromMemory(bundleRead);

        }

        public static UnityEngine.Object LoadAsset(string name)
            => AssetBundle.LoadAsset(name);
    }
}

