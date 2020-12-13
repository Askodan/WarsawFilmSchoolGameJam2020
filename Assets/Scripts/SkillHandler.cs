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
    //TODO: Disable particle systems
    //TODO: Refresh icons
  }

  public void buyArmSkill()
  {
    pclimbs.HandRight.ChangeLimb(true);
    pclimbs.HandLeft.ChangeLimb(true);
    //TODO: Ungrey icons
  }

  public void buyLegSkill()
  {
    pclimbs.LegRight.ChangeLimb(true);
    pclimbs.LegLeft.ChangeLimb(true);
    //TODO: Ungrey icons
  }

  public void buyWingSkill()
  {
    pclimbs.WingRight.ChangeLimb(true);
    pclimbs.WingLeft.ChangeLimb(true);
    //TODO: Ungrey icons
  }

  public void OnArmSkill()
  {
    if(activeCounter > 0)
      return;
    if(!pc.energyDrain(skillCost[2]))
      return;
    prot.bumpAcceleration();
    //TODO: Activate particle system
    //TODO: Enabled form of icon
    activeCounter = skillTime[2];
  }

  public void OnLegSkill()
  {
    if(activeCounter > 0)
      return;
    if(!pc.energyDrain(skillCost[1]))
      return;
    pc.bumpSpeed();
    //TODO: Activate particle system
    //TODO: Enabled form of icon
    activeCounter = skillTime[1];
  }

  public void OnWingSkill()
  {
    if(activeCounter > 0)
      return;
    if(!pc.energyDrain(skillCost[0]))
      return;
    prot.bumpDumpPower();
    //TODO: Activate particle system
    //TODO: Enabled form of icon
    activeCounter = skillTime[0];
  }
}
