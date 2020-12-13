using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectObjectActivation : SkillEffect
{
    [SerializeField]
    private GameObject ToActivate;
    public override void Activate()
    {
        ToActivate.SetActive(true);
    }
    public override void Deactivate()
    {
        ToActivate.SetActive(false);
    }
}
