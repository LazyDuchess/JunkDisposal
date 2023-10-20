using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Configuration;

namespace SmootherTraversal
{
    internal class JunkDisposalSettings
    {
        public static bool RemoveJunk => _removeJunk.Value;
        public static bool RemoveGroundPoles => _removeGroundPoles.Value;
        public static bool LightObstacles => _lightObstacles.Value;
        public static bool RemoveCars => _removeCars.Value;
        public static bool RemovePeople => _removePeople.Value;

        private static ConfigEntry<bool> _removeJunk;
        private static ConfigEntry<bool> _removeGroundPoles;
        private static ConfigEntry<bool> _lightObstacles;
        private static ConfigEntry<bool> _removeCars;
        private static ConfigEntry<bool> _removePeople;

        public static void Initialize(ConfigFile config)
        {
            _removeJunk = config.Bind("General",
                "RemoveJunk",
                false,
                "Removes physics props from levels that can get in the way.");

            _removeGroundPoles = config.Bind("General",
                "RemoveGroundPoles",
                true,
                "Removes static small bits or poles on the ground that can stop you in your tracks if you hit them.");

            _lightObstacles = config.Bind("General",
                "LightObstacles",
                true,
                "Makes it possible to hit props without losing speed.");

            _removeCars = config.Bind("General",
                "RemoveCars",
                false,
                "Removes all cars from levels.");

            _removePeople = config.Bind("General",
                "RemovePeople",
                false,
                "Removes all people walking around in levels.");
        }
    }
}
