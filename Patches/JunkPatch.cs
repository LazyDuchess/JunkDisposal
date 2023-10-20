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
    [HarmonyPatch(typeof(Junk))]
    internal class JunkPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(Junk.Init))]
        private static void Init_Postfix(Junk __instance)
        {
            if (!JunkDisposalSettings.LightObstacles)
                return;
            var rb = __instance.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.isKinematic = false;
            }
        }
    }
}
