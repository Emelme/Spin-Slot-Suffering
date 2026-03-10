using System.Collections;
using Febucci.TextAnimatorForUnity.TextMeshPro;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int money;
    public int moneyToDisplay;
    public float moneyToDisplaySpeed;
    
    public TextAnimator_TMP textAnim;
    public TextMeshProUGUI textMeshPro;
    
    public static MoneyManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        money = GameData.instance.startMoney;
        textAnim.SetText(money.ToString("D10"));
        
        StartCoroutine(UpdateMoneyVisuals());
    }
    
    public void AddMoney(int money)
    {
        this.money += money;
    }

    public void RemoveMoney(int money)
    {
        this.money -= money;
    }
    
    private IEnumerator UpdateMoneyVisuals()
    {
        while (true)
        {
            if (moneyToDisplay < money)
            {
                if (money - moneyToDisplay > 100)
                {
                    moneyToDisplay += 100;
                }
                else if (money - moneyToDisplay > 10)
                {
                    moneyToDisplay += 10;
                }
                else
                {
                    moneyToDisplay++;
                }

                textAnim.SetText("<dangle a=0.3><wave a=0.3>" + moneyToDisplay.ToString("D10"));
                yield return null;
            }
            else if (moneyToDisplay > money)
            {
                if (moneyToDisplay - money > 100)
                {
                    moneyToDisplay -= 100;
                }
                else if (moneyToDisplay - money > 10)
                {
                    moneyToDisplay -= 10;
                }
                else
                {
                    moneyToDisplay--;
                }

                textAnim.SetText("<dangle a=0.3><wave a=0.3>" + moneyToDisplay.ToString("D10"));
                yield return null;
            }
            else
            {
                yield return null;
            }
        }
    }
}
