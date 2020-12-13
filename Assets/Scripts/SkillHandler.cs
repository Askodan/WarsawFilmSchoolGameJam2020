using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SkillHandler : MonoBehaviour {
  public float[] skillTime;
  public float[] skillCost;
  private PlayerRotation prot;
  private PlayerChangeLimbs pclimbs;
  private Player pc;

  private float activeCounter;

  public void Start()
  {
    prot = FindObjectOfType<PlayerRotation>();
    pclimbs = FindObjectOfType<PlayerChangeLimbs>();
    pc = FindObjectOfType<Player>();
  }

  public void Update()
  {
    if (activeCounter > 0)
    {
      activeCounter -= Time.deltaTime;
      if (activeCounter <= 0)
      {
        disableSkills();
      }
    }
  }

  private void disableSkills()
  {
    prot.debumpDumpPower();
    prot.debumpAcceleration();
    pclimbs.HandRight.ChangeLimb(false);
    pclimbs.HandLeft.ChangeLimb(false);
    pclimbs.LegRight.ChangeLimb(false);
    pclimbs.LegLeft.ChangeLimb(false);
    pclimbs.WingRight.ChangeLimb(false);
    pclimbs.WingLeft.ChangeLimb(false);
  }

  public void OnArmSkill()
  {
    if(activeCounter > 0)
      return;
    if(!pc.energyDrain(skillCost[2]))
      return;
    prot.bumpAcceleration();
    pclimbs.HandRight.ChangeLimb(true);
    pclimbs.HandLeft.ChangeLimb(true);
    activeCounter = skillTime[2];
  }

  public void OnLegSkill()
  {
    if(activeCounter > 0)
      return;
    if(!pc.energyDrain(skillCost[1]))
      return;
    pc.bumpSpeed();
    pclimbs.LegRight.ChangeLimb(true);
    pclimbs.LegLeft.ChangeLimb(true);
    activeCounter = skillTime[1];
  }

  public void OnWingSkill()
  {
    if(activeCounter > 0)
      return;
    if(!pc.energyDrain(skillCost[0]))
      return;
    prot.bumpDumpPower();
    pclimbs.WingRight.ChangeLimb(true);
    pclimbs.WingLeft.ChangeLimb(true);
    activeCounter = skillTime[0];
  }
}
