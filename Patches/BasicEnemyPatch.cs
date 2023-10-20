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
    [HarmonyPatch(typeof(BasicEnemy))]
    internal static class BasicEnemyPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(BasicEnemy.Setup))]
        private static void Init(BasicEnemy __instance)
        {
            if (!JunkDisposalSettings.LightObstacles)
                return;
            var bodies = __instance.GetComponentsInChildren<Rigidbody>();
            foreach(var body in bodies)
            {
                body.mass *= 2000f;
            }
        }
    }
}
