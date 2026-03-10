using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public Image image;
	public TextMeshProUGUI text;
	
	public InventoryItemType item = InventoryItemType.air;
	
	public int amount;

	private void Update()
	{
		image.sprite = PrefabsManager.instance.GetInventoryItemSprite(item);
		text.text = amount.ToString();

		if (item == InventoryItemType.air)
		{
			transform.GetChild(0).gameObject.SetActive(false);
		}
		else
		{
			transform.GetChild(0).gameObject.SetActive(true);
		}
	}

	public void AddItem()
	{
		amount++;
	}

	public void RemoveItem()
	{
		amount--;
		item = InventoryItemType.air;
	}
	
	public void InitializeItem(InventoryItemType item)
	{
		this.item = item;
		
		amount = 1;
	}
	
	public void OnButtonClick()
	{
		Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
		
		GameObject gameObject = Instantiate(PrefabsManager.instance.standartSlotMachine,  mouseWorld, Quaternion.identity);
		
		
	}
}

