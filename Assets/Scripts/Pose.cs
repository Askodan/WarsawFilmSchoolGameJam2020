using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pose
{
    [SerializeField]
    private string name;

    [SerializeField]
    private bool[] takenFields;
    [SerializeField]
    private GameObject visualization;
    public string Name { get => name; }
    public bool[] TakenFields { get => takenFields; }

    public void Show()
    {
        visualization.SetActive(true);
    }
    public void Hide()
    {
        visualization.SetActive(false);
    }
}
