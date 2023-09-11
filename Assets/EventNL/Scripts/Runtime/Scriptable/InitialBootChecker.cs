using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NL.Event
{
    public static class InitialBootChecker
    {
        public static bool IsChecked { get; private set; } = false;
        public static bool IsInitialBoot { get; private set; }
        private static readonly string InitialBootKey = "InitialBootKey_InitialBootChecker";
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Checker()
        {
            if (PlayerPrefs.HasKey(InitialBootKey))
            {
                IsInitialBoot = false;
            }
            else
            {
                IsInitialBoot = true;
                PlayerPrefs.SetString(InitialBootKey, "data");
            }
            IsChecked = true;
        }
    }
}