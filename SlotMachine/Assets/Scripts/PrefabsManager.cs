using System;
using UnityEngine;

public class PrefabsManager :  MonoBehaviour
{
	public Sprite airSprite;
	
	public GameObject standartSlotMachine;
	public Sprite standartSlotMachineSprite;
	
	public static PrefabsManager instance;

	private void Awake()
	{
		instance = this;
	}

	public GameObject GetInventoryItem(InventoryItemType item)
	{
		switch (item)
		{
			case InventoryItemType.air:
				break;
			case InventoryItemType.StandartSlotMachine:
				return standartSlotMachine;
				break;
			default:
				break;
		}
		
		return null;
	}
	
	public Sprite GetInventoryItemSprite(InventoryItemType item)
	{
		switch (item)
		{
			case InventoryItemType.air:
				return airSprite;
				break;
			case InventoryItemType.StandartSlotMachine:
				return standartSlotMachineSprite;
				break;
			default:
				break;
		}
		
		return null;
	}
}
