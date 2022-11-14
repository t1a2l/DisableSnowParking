using ColossalFramework.Threading;
using HarmonyLib;
using System;
using System.Linq;

namespace DisableSnowParking
{
    [HarmonyPatch(typeof(BuildingPropertiesWinter), "GenerateSnow", new Type[] { typeof(BuildingInfoBase)}, new ArgumentType[] { ArgumentType.Normal })]
    static class GenerateSnowPatch
    {
        [HarmonyPrefix]
        public static void Prefix(BuildingInfoBase info, ref Task __result)
	    {
            var steam_parkings = new [] {"1293869603", "1285201733", "1293869603", "2116510188", "2115188517", "2121900156"};           
            if (info.GetAI() is ParkAI && info.name.Contains("2174913158") || info.GetAI() is BuildingAI && steam_parkings.Any(info.name.Contains))
            {
                info.m_disableSnow = true;
            }
	    }
    }
}