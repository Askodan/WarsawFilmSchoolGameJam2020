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

  private string armLastStatus = "locked";
  private string legLastStatus = "locked";
  private string wingLastStatus = "locked";

  public string armStatus = "locked";
  public string legStatus = "locked";
  public string wingStatus = "locked";

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
    if(pc.skillBlockTimer > 0)
    {
      if(armStatus != "locked")
        armStatus = "blocked";
      if(legStatus != "locked")
        legStatus = "blocked";
      if(wingStatus != "locked")
        wingStatus = "blocked";
    }
    if(armLastStatus != armStatus)
    {
      //TODO: call UI
    }
    if(legLastStatus != legStatus)
    {
      //TODO: call UI
    }
    if(wingLastStatus != wingStatus)
    {
      //TODO: call UI
    }
  }

  private void disableSkills()
  {
    prot.debumpDumpPower();
    prot.debumpAcceleration();
    if(pc.skillBlockTimer <= 0)
    {
      armStatus = "inactive";
      legStatus = "inactive";
      wingStatus = "inactive";
    }
    //TODO: Disable particle systems
    //TODO: Refresh icons
  }

  public void buyArmSkill()
  {
    pclimbs.HandRight.ChangeLimb(true);
    pclimbs.HandLeft.ChangeLimb(true);
    armStatus = "inactive";
    //TODO: Ungrey icons
  }

  public void buyLegSkill()
  {
    pclimbs.LegRight.ChangeLimb(true);
    pclimbs.LegLeft.ChangeLimb(true);
    legStatus = "inactive";
    //TODO: Ungrey icons
  }

  public void buyWingSkill()
  {
    pclimbs.WingRight.ChangeLimb(true);
    pclimbs.WingLeft.ChangeLimb(true);
    wingStatus = "inactive";
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
    armStatus = "active";
    legStatus = "inactive";
    wingStatus = "inactive";
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
    armStatus = "inactive";
    legStatus = "active";
    wingStatus = "inactive";
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
    armStatus = "inactive";
    legStatus = "inactive";
    wingStatus = "active";
  }
}
