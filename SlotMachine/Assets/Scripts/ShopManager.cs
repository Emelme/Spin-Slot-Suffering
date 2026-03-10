using System.Collections;
using Febucci.TextAnimatorForUnity.TextMeshPro;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public InventoryItem item;

    public int[] prices;

    private int priceIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    public void Buy()
    {
        MoneyManager.instance.RemoveMoney(prices[priceIndex]);
        priceIndex++;
        
        InventoryManager.instance.Add(item);
    }
}
