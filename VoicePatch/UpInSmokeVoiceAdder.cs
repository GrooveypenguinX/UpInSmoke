using System;
using BepInEx;
using UnityEngine;

namespace UpInSmokeVoiceAdder
{

    [BepInPlugin("com.grooveypenguinx.basedonCWXVoiceAdder.cheechandchongvoiceadder", "CheechAndChong Adder", "0.6.9")]
    public class UpInSmokeVoiceAdder : BaseUnityPlugin
    {
        private void Start()
        {
            new UpInSmokeVoicePatch().Enable();
        }
    }
}