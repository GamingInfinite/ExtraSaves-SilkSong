using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine.UI;

namespace ExtraSaves.Extensions
{
    public static class SaveSlotButtonExt
    {
        public static SaveStats GetSaveStats(this SaveSlotButton button)
        {
            return Traverse.Create(button).Field("saveStats").GetValue<SaveStats>();
        }

        public static void AltPresentSaveSlot(this SaveSlotButton button, SaveStats saveStats)
        {
            Traverse.Create(button).Method("PresentSaveSlot", [saveStats]).GetValue();
        }
    }
}
