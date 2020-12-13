using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Modifier
{
    [SerializeField]
    public string what;
    [SerializeField]
    public float amount;
    public Modifier(string w, float a)
    {
        what = w;
        amount = a;
    }
}
