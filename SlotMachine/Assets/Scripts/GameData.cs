using UnityEngine;

public class GameData : MonoBehaviour
{
    public int startMoney;

    [Header("standartSlotMachine")]
    public int slotMachinePriceToSpin;
    public float slotMachinePokerChipSpawnTime;
    [Space]

    public float slotMachineJackpotChance;
    [Space]

    public int slotMachineBananaAmount;
    public float slotMachineChanceBanana;
    public int slotMachineJackpotBananaPokerChipAmount;
    [Space]
    
    public int slotMachineCherryAmount;
    public float slotMachineChanceCherry;
    public int slotMachineJackpotCherryPokerChipAmount;
    [Space]
    
    public int slotMachineCleverAmount;
    public float slotMachineChanceClever;
    public int slotMachineJackpotCleverPokerChipAmount;
    [Space]
    
    public int slotMachineSevenAmount;
    public float slotMachineChanceSeven;
    public int slotMachineJackpotSevenPokerChipAmount;
    [Space]

    public static GameData instance;

    private void Awake()
    {
        instance = this;
    }

    public bool WillBeJackpot()
    {
        return Random.value <= slotMachineJackpotChance;
    }

    public SingleSlotType GetSingleSlotType()
    {
        float totalChance =
            slotMachineChanceBanana +
            slotMachineChanceCherry +
            slotMachineChanceClever +
            slotMachineChanceSeven;

        float roll = Random.value * totalChance;

        float cumulative = 0f;

        cumulative += slotMachineChanceBanana;
        if (roll < cumulative)
            return SingleSlotType.banana;

        cumulative += slotMachineChanceCherry;
        if (roll < cumulative)
            return SingleSlotType.cherry;

        cumulative += slotMachineChanceClever;
        if (roll < cumulative)
            return SingleSlotType.clever;

        return SingleSlotType.seven;
    }

    public int GetPokerChipAmountBySingleSlotType(SingleSlotType singleSlotType)
    {
        switch (singleSlotType)
        {
            case SingleSlotType.banana:
                return slotMachineBananaAmount;
                break;
            case SingleSlotType.cherry:
                return slotMachineCherryAmount;
                break;
            case SingleSlotType.clever:
                return slotMachineCleverAmount;
                break;
            case SingleSlotType.seven:
                return slotMachineSevenAmount;
                break;
            default:
                return 0;
                break;
        }
    }

    public int GetPokerChipAmountForJackpot(SingleSlotType singleSlotType)
    {
        switch (singleSlotType)
        {
            case SingleSlotType.banana:
                return slotMachineJackpotBananaPokerChipAmount;
                break;
            case SingleSlotType.cherry:
                return slotMachineJackpotCherryPokerChipAmount;
                break;
            case SingleSlotType.clever:
                return slotMachineJackpotCleverPokerChipAmount;
                break;
            case SingleSlotType.seven:
                return slotMachineJackpotSevenPokerChipAmount;
                break;
            default:
                return 0;
                break;
        }
    }
}
