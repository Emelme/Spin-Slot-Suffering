using System;
using System.Collections;
using UnityEngine;

public class PokerChipPool : MonoBehaviour
{
    public static PokerChipPool instance;
    
    public Transform pokerChipPoolTransform;
    public PokerChip pokerChips;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnPokerChipsInPool());
    }

    private void Update()
    {
    }

    public PokerChip GetPokerChip()
    {
        PokerChip pc = pokerChipPoolTransform.GetChild(0).GetComponent<PokerChip>();
        
        pc.transform.parent = null;
        pc.transform.position = Vector3.zero;
        pc.transform.localPosition = Vector3.zero;
        
        return pc;
    }

    public void SendToPokerPool(PokerChip pc)
    {
        pc.transform.SetParent(pokerChipPoolTransform);
    }

    private IEnumerator SpawnPokerChipsInPool()
    {
        int x = 10;
        int y = 300;

        for (int j = 0; j < y; j++)
        {
            for (int i = 0; i < x; i++)
            {
                Instantiate(pokerChips, pokerChipPoolTransform);
            }

            yield return null;
        }
    }
}
