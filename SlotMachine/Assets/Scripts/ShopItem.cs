using System.Collections;
using Febucci.TextAnimatorForUnity.TextMeshPro;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public InventoryItemType item;

    public int price;
    public int priceMult;

    private string richText = "<dangle a=0.3><wave a=0.3>";
    public TextAnimator_TMP priceText;
    
    public static ShopItem instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        priceText.SetText("" + richText + price.ToString());
    }
    
    public void Buy()
    {
        Debug.Log("");
        
        MoneyManager.instance.RemoveMoney(price);

        price *= priceMult;
        
        InventoryManager.instance.AddInventoryItem(item);
    }
}
