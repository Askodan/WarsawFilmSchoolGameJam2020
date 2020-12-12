using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private EnergyBarController energy;
  // private MoneyController money;
  private LevelProgress speed;

  public void affect(Modifier[] modifiers)
  {
    foreach(Modifier m in modifiers)
    {
      switch(m.what)
      {
        case "energy":
          energy.modifyEnergy(m.amount);
          break;
        case "money":
          // money.modifyMoney(m.amount);
          break;
        case "speed":
          speed.modifySpeed(m.amount);
          break;
      }
    }
  }

  public void Start()
  {
    energy = FindObjectOfType<EnergyBarController>();
    // money =  FindObjectOfType<MoneyController>();
    speed = FindObjectOfType<LevelProgress>();
  }
}
