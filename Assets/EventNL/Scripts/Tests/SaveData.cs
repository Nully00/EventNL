using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NL.Event;
[CreateAssetMenu(fileName = "SaveData", menuName = "EventNL/Tests/SaveData")]
public class SaveData : InitializerScriptableObject<A>
{

    public override void SetDefaultValues()
    {
        value = new A(1, 2);
    }
}
[System.Serializable]
public class A
{
    public float name;
    public float description;

    public A(float name, float description)
    {
        this.name = name;
        this.description = description;
    }
}