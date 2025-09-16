using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;

namespace ExtraSaves.Patches
{
    [HarmonyPatch(typeof(Platform), nameof(Platform.IsSaveSlotIndexValid))]
    internal class _099ValidSaves
    {
        [HarmonyPrefix]
        public static bool Postfix(int slotIndex, ref bool __result)
        {
            __result = slotIndex >= 0;
            return false;
        }
    }
}
