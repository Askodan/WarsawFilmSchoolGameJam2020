using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private EnergyBarController energy;
  // private MoneyController money;
  private LevelProgress speed;

  public float energyValue;
  public int moneyValue;
  public float maxSpeed = 30f;
  public float minSpeed = 1f;
  public float speedValue;
  private float initialSpeedValue;

  public float skillBlockTimer;

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
          speedValue = Mathf.Clamp(speedValue, minSpeed, maxSpeed);
          speed.modifySpeed(speedValue);
          break;
        case "skillblock":
          skillBlockTimer += m.amount;
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
    initialSpeedValue = speedValue;
  }

  public void Update()
  {
    if(skillBlockTimer > 0)
      skillBlockTimer -= Time.deltaTime;
    if(skillBlockTimer < 0)
      skillBlockTimer = 0;
    float velDiff = speedValue - initialSpeedValue;
    if (Mathf.Abs(velDiff) > 0.01f)
    {
        speedValue -= velDiff * 0.01f;
        speed.modifySpeed(speedValue);
    }
  }

  public void bumpSpeed()
  {
    speedValue = maxSpeed;
    speed.modifySpeed(speedValue);
  }

  public bool energyDrain(float value)
  {
    if(skillBlockTimer > 0)
      return false;
    if(energyValue < value)
      return false;
    energyValue -= value;
    energyValue = Mathf.Clamp(energyValue, 0.0f, 1.0f);
    energy.modifyEnergy(energyValue);
    return true;
  }
}
