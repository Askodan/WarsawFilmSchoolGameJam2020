using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

class Counter
{
    public bool Bought { get; set; } = false;

    private float counter;
    private bool active;

    public bool Active { get => active; private set => active = value; }
    public bool Used { get; set; } = false;
    public void Activate(float val)
    {
        counter = val;
        active = true;
    }
    public void Update(float diff)
    {
        if (counter > 0)
        {
            counter -= diff;
            if (counter <= 0)
            {
                Active = false;
                Used = false;
            }
        }
    }
}
public class SkillHandler : MonoBehaviour
{
    public float[] skillTime;
    public float[] skillCost;
    private PlayerRotation prot;
    private PlayerChangeLimbs pclimbs;
    private Player pc;

    private Counter activeCounterHands = new Counter();
    private Counter activeCounterLegs = new Counter();
    private Counter activeCounterWings = new Counter();

    public void Start()
    {
        prot = FindObjectOfType<PlayerRotation>();
        pclimbs = FindObjectOfType<PlayerChangeLimbs>();
        pc = FindObjectOfType<Player>();
    }

    public void Update()
    {
        activeCounterHands.Update(Time.deltaTime);
        activeCounterLegs.Update(Time.deltaTime);
        activeCounterWings.Update(Time.deltaTime);

        if (!activeCounterHands.Used)
        {
            prot.debumpAcceleration();
            pclimbs.HandRight.effect.Deactivate();
            pclimbs.HandLeft.effect.Deactivate();
            activeCounterHands.Used = true;
        }
        if (!activeCounterLegs.Used)
        {
            pclimbs.LegRight.effect.Deactivate();
            pclimbs.LegLeft.effect.Deactivate();
            activeCounterLegs.Used = true;
        }
        if (!activeCounterWings.Used)
        {
            pclimbs.WingRight.effect.Deactivate();
            pclimbs.WingLeft.effect.Deactivate();
            prot.debumpDumpPower();
            activeCounterWings.Used = true;
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
        activeCounterHands.Bought = true;
        //TODO: Ungrey icons
    }

    public void buyLegSkill()
    {
        pclimbs.LegRight.ChangeLimb(true);
        pclimbs.LegLeft.ChangeLimb(true);
        activeCounterLegs.Bought = true;
        //TODO: Ungrey icons
    }

    public void buyWingSkill()
    {
        pclimbs.WingRight.ChangeLimb(true);
        pclimbs.WingLeft.ChangeLimb(true);
        activeCounterWings.Bought = true;
        //TODO: Ungrey icons
    }

    public void OnArmSkill()
    {
        if (activeCounterHands.Active || !activeCounterHands.Bought)
            return;
        if (!pc.energyDrain(skillCost[2]))
            return;

        prot.bumpAcceleration();
        pclimbs.HandRight.effect.Activate();
        pclimbs.HandLeft.effect.Activate();
        //TODO: Enabled form of icon
        activeCounterHands.Activate(skillTime[2]);
    }

    public void OnLegSkill()
    {
        if (activeCounterLegs.Active || !activeCounterLegs.Bought)
            return;
        if (!pc.energyDrain(skillCost[1]))
            return;
        pc.bumpSpeed();
        pclimbs.LegRight.effect.Activate();
        pclimbs.LegLeft.effect.Activate();
        //TODO: Enabled form of icon
        activeCounterLegs.Activate(skillTime[1]);
    }

    public void OnWingSkill()
    {
        if (activeCounterWings.Active || !activeCounterWings.Bought)
            return;
        if (!pc.energyDrain(skillCost[0]))
            return;
        prot.bumpDumpPower();
        pclimbs.WingRight.effect.Activate();
        pclimbs.WingLeft.effect.Activate();
        //TODO: Enabled form of icon
        activeCounterWings.Activate(skillTime[0]);
    }
}
