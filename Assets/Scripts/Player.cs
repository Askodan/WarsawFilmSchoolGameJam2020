using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private EnergyBarController energy;
  // private MoneyController money;
  private LevelProgress speed;

  public float energyValue;
  public int moneyValue;
  public float speedValue;

  public void affect(Modifier[] modifiers)
  {
    foreach(Modifier m in modifiers)
    {
      switch(m.what)
      {
        case "energy":
          energyValue += m.amount;
          energyValue = Mathf.Clamp(energyValue, 0.0f, 1.0f);
          energy.modifyEnergy(energyValue);
          break;
        case "money":
          // moneyValue += (int)m.amount;
          // moneyValue = Mathf.Clamp(moneyValue, 0.0f, 1000.0f);
          // money.modifyMoney(moneyValue);
          break;
        case "speed":
          speedValue += m.amount;
          speedValue = Mathf.Clamp(speedValue, 0.0f, 30.0f);
          speed.modifySpeed(speedValue);
          break;
      }
    }
  }

  public void Start()
  {
    energy = FindObjectOfType<EnergyBarController>();
    energy.modifyEnergy(energyValue);
    // money =  FindObjectOfType<MoneyController>();
    // money.modifyMoney(moneyValue);
    speed = FindObjectOfType<LevelProgress>();
    speed.modifySpeed(speedValue);
  }
}
