using System.Collections;
using Febucci.TextAnimatorForUnity.TextMeshPro;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public InventoryItemType item;

    public int[] prices;

    private string richText = "<dangle a=0.3><wave a=0.3>";
    public TextAnimator_TMP priceText;
    
    private int priceIndex = 0;
    
    public static ShopItem instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        priceText.SetText("" + richText + prices[priceIndex].ToString());
    }
    
    public void Buy()
    {
        Debug.Log("");
        
        MoneyManager.instance.RemoveMoney(prices[priceIndex]);
        priceIndex++;
        
        InventoryManager.instance.AddInventoryItem(item);
    }
}
