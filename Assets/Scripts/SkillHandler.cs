using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHandler : MonoBehaviour {
  public float[] skillTime;
  private PlayerRotation prot;

  public Start()
  {
    prot = FindObjectOfType<PlayerRotation>();
  }

  public Update()
  {
    
  }

  private void OnArmSkill(InputValue value)
  {

  }

  private void OnLegSkill(InputValue value)
  {

  }

  private void OnWingSkill(InputValue value)
  {

  }
}
