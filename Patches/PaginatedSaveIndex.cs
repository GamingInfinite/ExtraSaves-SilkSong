using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace ExtraSaves.Patches
{
    [HarmonyPatch(typeof(SaveSlotButton), nameof(SaveSlotButton.SaveSlotIndex), MethodType.Getter)]
    internal class PaginatedSaveIndex
    {
        [HarmonyPostfix]
        public static void Postfix(SaveSlotButton __instance, ref int __result)
        {
            __result = __result + (4*(ExtraSaves.page-1));
            Text slotNumberText = __instance.slotNumberText.GetComponent<Text>();
            RectTransform rect = __instance.slotNumberText.transform.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(120, 154);
            if(slotNumberText != null)
            {
                slotNumberText.text = $"{__result}.";
            }
        }
    }
}
