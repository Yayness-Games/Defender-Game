using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] string itemName;

    public void bought()
    {
        Debug.Log("Attempting to buy...");
        if(GetComponentInParent<Shop>().money >= cost)
        {
            Debug.Log("buying...");
            GetComponentInParent<Shop>().money -= cost;
            GetComponentInParent<Shop>().addition(itemName);
        }
    }

    public int GetItemCost()
    {
        return cost;
    }

    public string GetItemName()
    {
        return itemName;
    }
}
