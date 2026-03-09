using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.Animations;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    public Animator animator;
    
    public Transform DOTweenTransform;
    public Vector3 DOScaleAmount;
    public float DOScaleSpeed;
    
    public SingleSlotAnimation singleSlotAnimation1;
    public SingleSlotAnimation singleSlotAnimation2;
    public SingleSlotAnimation singleSlotAnimation3;

    private void Start()
    {
        StartCoroutine(SpanwPokerChips());
    }

    private IEnumerator SpanwPokerChips()
    {
        yield return new WaitForSeconds(1f);
        
        while (true)
        {
            
            
            SingleSlotType singleSlotType1;
            SingleSlotType singleSlotType2;
            SingleSlotType singleSlotType3;
            
            animator.SetTrigger("SlotRun");
            
            singleSlotAnimation1.StartMotionAnimation();
            singleSlotAnimation2.StartMotionAnimation();
            singleSlotAnimation3.StartMotionAnimation();

            DOTweenTransform.DOPunchScale(DOScaleAmount, DOScaleSpeed);
            
            yield return CustomCoroutine.WaitOnCondition(() =>
            {
                AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
                return !(state.IsName("SlotRun") && state.normalizedTime >= 1f);
            });

            yield return new WaitForSeconds(GameData.instance.slotMachinePokerChipSpawnTime * 0.2f);
            
            int pokerChipSum = 0;
            
            if (GameData.instance.WillBeJackpot())
            {
                singleSlotType1 = GameData.instance.GetSingleSlotType();
                singleSlotType2 = singleSlotType1;
                singleSlotType3 = singleSlotType1;
                
                singleSlotAnimation1.StopMotionAnimation(singleSlotType1);
                singleSlotAnimation2.StopMotionAnimation(singleSlotType2);
                singleSlotAnimation3.StopMotionAnimation(singleSlotType3);
                
                pokerChipSum += GameData.instance.GetPokerChipAmountForJackpot(singleSlotType1);
            }
            else
            {
                singleSlotType1 = GameData.instance.GetSingleSlotType();
                singleSlotType2 = GameData.instance.GetSingleSlotType();
                singleSlotType3 = GameData.instance.GetSingleSlotType();
                
                // is jackpot anyway
                if (singleSlotType1 == singleSlotType2 && singleSlotType3 == singleSlotType1)
                {
                    singleSlotAnimation1.StopMotionAnimation(singleSlotType1);
                    singleSlotAnimation2.StopMotionAnimation(singleSlotType2);
                    singleSlotAnimation3.StopMotionAnimation(singleSlotType3);
                
                    pokerChipSum += GameData.instance.GetPokerChipAmountForJackpot(singleSlotType1);
                }
                
                singleSlotAnimation1.StopMotionAnimation(singleSlotType1);
                singleSlotAnimation2.StopMotionAnimation(singleSlotType2);
                singleSlotAnimation3.StopMotionAnimation(singleSlotType3);

                pokerChipSum += GameData.instance.GetPokerChipAmountBySingleSlotType(singleSlotType1);
                pokerChipSum += GameData.instance.GetPokerChipAmountBySingleSlotType(singleSlotType2);
                pokerChipSum += GameData.instance.GetPokerChipAmountBySingleSlotType(singleSlotType3);
            }
            
            yield return new WaitForSeconds(GameData.instance.slotMachinePokerChipSpawnTime * 0.1f);
            
            for (int i = 0; i < pokerChipSum; i++)
            {
                PokerChip pc = PokerChipPool.instance.GetPokerChip();
                pc.transform.position = transform.position;
                pc.StartAnim();
            }
            
            yield return new WaitForSeconds(GameData.instance.slotMachinePokerChipSpawnTime * 0.7f);
        }
    }
}
