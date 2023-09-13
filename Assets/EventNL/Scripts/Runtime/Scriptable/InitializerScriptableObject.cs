using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace NL.Event
{
    public abstract class InitializerScriptableObject<T> : InitializerScriptableObjectBase
    {
        [SerializeField]
        private string _saveKey;
        public string saveKey => _saveKey;
        public T value = default(T);
        public override void SetDefaultValues()
        {
            value = default(T);
        }
        public override void Save()
        {
            PlayerPrefsSaveService.Save<T>(_saveKey, value);
        }
        public override void Load()
        {
            if (PlayerPrefsSaveService.Load<T>(_saveKey, out T data))
            {
                value = data;
            }
            else
            {
                SetDefaultValues();
            }
        }
        public override void ResetData()
        {
            PlayerPrefs.DeleteKey(_saveKey);
        }

        private void Reset()
        {
            _saveKey = $"{this.GetInstanceID()}_{UnityEngine.Random.Range(int.MinValue, int.MaxValue)}";
        }
    }

    public abstract class InitializerScriptableObjectBase : SetDefaultValuesScriptableObject
    {
        public abstract void Save();
        public abstract void Load();
        public abstract void ResetData();
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(InitializerScriptableObjectBase), true)]
    public class InitializerScriptableObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (GUILayout.Button("Save"))
            {
                InitializerScriptableObjectBase tar = (InitializerScriptableObjectBase)target;
                tar.Save();
            }
            if (GUILayout.Button("Load"))
            {
                InitializerScriptableObjectBase tar = (InitializerScriptableObjectBase)target;
                tar.Load();
            }
            if (GUILayout.Button("Reset"))
            {
                InitializerScriptableObjectBase tar = (InitializerScriptableObjectBase)target;
                tar.ResetData();
            }
        }
    }
#endif

}