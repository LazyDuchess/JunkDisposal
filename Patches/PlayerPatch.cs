using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Reptile;
using UnityEngine;

namespace SmootherTraversal.Patches
{
    [HarmonyPatch(typeof(Player))]
    internal class PlayerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(Player.Init))]
        private static void Init_Postfix(Player __instance)
        {
            if (!JunkDisposalSettings.LightObstacles)
                return;
            __instance.motor._rigidbody.mass = 2000f;
        }
        [HarmonyPrefix]
        [HarmonyPatch(nameof(Player.OnCollisionEnter))]
        private static void OnCollisionEnter_Prefix(Player __instance, Collision other)
        {
            if (!JunkDisposalSettings.LightObstacles)
                return;
            var junk = other.transform.GetComponent<Junk>();
            if (junk)
                junk.FallApart(true);
        }
    }
}
