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
    [HarmonyPatch(typeof(JunkBehaviour))]
    internal class JunkBehaviourPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(JunkBehaviour.RestoreSingle))]
        private static void RestoreSingle_Postfix(Junk junk)
        {
            if (!JunkDisposalSettings.LightObstacles)
                return;
            var rb = junk.GetComponent<Rigidbody>();
            if (rb)
                rb.isKinematic = false;
        }
    }
}
