using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int money = 0;
    [SerializeField] Text moneyText;
    [SerializeField] Text inventory;

    public void addition(string item)
    {
        moneyText.text = money.ToString();
        inventory.text += "\n" + item;
    }
}
