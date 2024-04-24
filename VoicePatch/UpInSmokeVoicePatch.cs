﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Aki.Reflection.Patching;
using Aki.Reflection.Utils;
using HarmonyLib;
using Newtonsoft.Json;

namespace UpInSmokeVoiceAdder
{

    public class UpInSmokeVoicePatch : ModulePatch
    {

        public UpInSmokeVoicePatch()
        {
            UpInSmokeVoicePatch._targetType = Enumerable.Single<Type>(PatchConstants.EftTypes, new Func<Type, bool>(this.IsTargetType));
        }


        private bool IsTargetType(Type type)
        {
            return type.GetMethod("TakePhrasePath") != null;
        }


        protected override MethodBase GetTargetMethod()
        {
            return UpInSmokeVoicePatch._targetType.GetMethod("TakePhrasePath");
        }


        [PatchPrefix]
        private static void PatchPrefix()
        {
            string text = new StreamReader("./user/mods/WTT-UpInSmoke/voices.json").ReadToEnd();
            Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
            Dictionary<string, string> value = Traverse.Create(UpInSmokeVoicePatch._targetType).Field<Dictionary<string, string>>("dictionary_0").Value;
            foreach (string key in dictionary.Keys)
            {
                string value2;
                dictionary.TryGetValue(key, out value2);
                bool flag = !value.ContainsKey(key);
                bool flag2 = flag;
                if (flag2)
                {
                    value.Add(key, value2);
                }
            }
        }

        private static Type _targetType;
    }
}
