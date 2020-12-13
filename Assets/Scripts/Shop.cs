using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class SkillCost
{
    public int price;
    [SerializeField]
    private Text priceTag;
    [SerializeField]
    private Button sellBut;
    public void Init()
    {
        priceTag.text = price.ToString();
        sellBut.enabled = true;
    }
    public bool Sell(MoneyController mc)
    {
        if (mc.money > price)
        {
            mc.money -= price;
            priceTag.text = "Sprzedane";
            sellBut.enabled = false;
            return true;
        }
        return false;
    }
}
public class Shop : MonoBehaviour
{
    [SerializeField]
    SkillCost priceArms;
    [SerializeField]
    SkillCost priceLegs;
    [SerializeField]
    SkillCost priceWings;
    [SerializeField]
    MoneyController mc;
    [SerializeField]
    SkillHandler sh;
    void Awake()
    {
        priceArms.Init();
        priceLegs.Init();
        priceWings.Init();
    }
    public void BuyArms()
    {
        if (priceArms.Sell(mc))
            sh.buyArmSkill();
    }
    public void BuyLegs()
    {
        if (priceLegs.Sell(mc))
            sh.buyLegSkill();
    }
    public void BuyWings()
    {
        if (priceWings.Sell(mc))
            sh.buyWingSkill();
    }
}
