using System;
using UnityEngine;

namespace NL.Event
{
    public static class PlayerPrefsSaveService
    {
        public static void Save<T>(string key, T data)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (data == null) throw new ArgumentNullException(nameof(data));

            string jsonString = JsonUtility.ToJson(data, true);
            PlayerPrefs.SetString(key, jsonString);
        }

        public static bool Load<T>(string key, out T data)
        {
            string jsonString = PlayerPrefs.GetString(key);
            if (jsonString == null || jsonString == "{}" || jsonString == "")
            {
                data = default(T);
                return false;
            }

            data = JsonUtility.FromJson<T>(jsonString);
            return true;
        }
    }
}

