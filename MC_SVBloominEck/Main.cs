﻿using BepInEx;
using BepInEx.Configuration;
using UnityEngine.PostProcessing;

namespace MC_SVBloominEck
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string pluginGuid = "mc.starvalor.bloomineck";
        public const string pluginName = "SV Bloomin' Eck!";
        public const string pluginVersion = "1.0.0";

        public ConfigEntry<float> cfg_Intensity;        

        public void Awake()
        {
            cfg_Intensity = Config.Bind<float>("Settings",
                "Bloom Intensity",
                0.01f,
                "");
        }

        public void Update()
        {
            if (SetupControl.inst && SetupControl.inst.ppp &&
                SetupControl.inst.ppp.bloom.settings.bloom.intensity != cfg_Intensity.Value)
            {
                BloomModel.Settings bms = SetupControl.inst.ppp.bloom.settings;
                bms.bloom.intensity = cfg_Intensity.Value;
                SetupControl.inst.ppp.bloom.settings = bms;
            }
        }
    }
}