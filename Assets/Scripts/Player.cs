using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private EnergyBarController energy;
  private MoneyController money;
  private LevelProgress speed;

  public float energyValue;
  public int moneyValue;
  public float speedValue;
  private float initialSpeedValue;

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
          moneyValue += (int)m.amount;
          moneyValue = Mathf.Clamp(moneyValue, 0, 1000);
          money.modifyMoney(moneyValue);
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
    money =  FindObjectOfType<MoneyController>();
    money.modifyMoney(moneyValue);
    speed = FindObjectOfType<LevelProgress>();
    speed.modifySpeed(speedValue);
    initialSpeedValue = speedValue;
  }

  public void Update()
  {
    float velDiff = speedValue - initialSpeedValue;
    if (Mathf.Abs(velDiff) > 0.01f)
    {
        speedValue -= velDiff * 0.01f;
        speed.modifySpeed(speedValue);
    }
  }
}
