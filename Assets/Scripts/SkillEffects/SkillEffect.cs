using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillEffect : MonoBehaviour
{
    void Awake()
    {
        Deactivate();
    }
    public abstract void Activate();
    public abstract void Deactivate();
}
