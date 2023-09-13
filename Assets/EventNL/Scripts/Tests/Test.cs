using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private SaveData _saveData;
    private void Start()
    {
        _saveData.Load();
        Debug.Log(_saveData.value.name);
        Debug.Log(_saveData.value.description);
    }
}
