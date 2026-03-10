using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public List<InventorySlot> slots;

	public static InventoryManager instance;

	private void Awake()
	{
		instance = this;
	}
	
	public void AddInventoryItem(InventoryItemType item)
	{
		bool hasBeenSetted = false;
		
		foreach (var slot in slots)
		{
			if (slot.item == item)
			{
				slot.AddItem();
				hasBeenSetted = true;
			}
		}

		if (!hasBeenSetted)
		{
			foreach (var slot in slots)
			{
				if (slot.item == InventoryItemType.air)
				{
					slot.InitializeItem(item);
					return;
				}
			}
		}
	}
}

public enum InventoryItemType
{
	air,
	StandartSlotMachine,
}
