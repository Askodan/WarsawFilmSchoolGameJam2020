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
        sellBut.interactable = true;
    }
    public bool Sell(Player player)
    {
        if (player.moneyValue >= price)
        {
            Modifier[] mod = { new Modifier("money", -price) };
            player.affect(mod);
            priceTag.text = "-";
            sellBut.interactable = false;
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
    Player player;
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
        if (priceArms.Sell(player))
            sh.buyArmSkill();
    }
    public void BuyLegs()
    {
        if (priceLegs.Sell(player))
            sh.buyLegSkill();
    }
    public void BuyWings()
    {
        if (priceWings.Sell(player))
            sh.buyWingSkill();
    }
}
