using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    public int money;

    private Text moneyDisplay;

    [SerializeField]
    private char moneySymbol;

    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        moneyDisplay = gameObject.GetComponent<Text>();
        modifyMoney(0);
    }

    public void modifyMoney(int modifier)
    {
      if(moneyDisplay != null) {
          money = modifier;
          moneyDisplay.text = money.ToString() + moneySymbol;
      }
    }
}
