using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace ExtraSaves
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class ExtraSaves : BaseUnityPlugin
    {
        public static int page = 1;
        public static ManualLogSource logSource;
        public static float cooldown = 0.0f;
        public static float pageCooldown = 0.25f;

        private void Awake()
        {
            // Put your initialization logic here
            logSource = Logger;
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} has loaded!");
            Harmony harmony = new("com.example.patch");
            harmony.PatchAll();
        }

        private void Update()
        {
            if (cooldown == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftBracket))
                {
                    PrevPage();
                }

                if (Input.GetKeyDown(KeyCode.RightBracket))
                {
                    NextPage();
                }
            }

            if (cooldown < 0)
            {
                cooldown = 0;
            }
            
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            }
        }

        public static void PrevPage()
        {
            if (page == 1)
            {
                return;
            }

            if (UIManager.instance.saveProfileScreen)
            {
                page--;
                ReloadProfiles();
            }
        }

        public static void NextPage()
        {
            if (page == 99)
            {
                return;
            }

            if (UIManager.instance.saveProfileScreen)
            {
                page++;
                ReloadProfiles();
            }
        }

        public static void ReloadProfiles()
        {
            cooldown = pageCooldown;

            UIManager ui = UIManager.instance;
            SaveSlotButton[] saveButtons = [ui.slotOne, ui.slotTwo, ui.slotThree, ui.slotFour];
            foreach (var saveButton in saveButtons)
            {
                saveButton.ResetButton(GameManager.instance);
            }
        }
        
        public static void Log(string msg)
        {
            logSource.LogInfo(msg);
        }
    }
}