using System;
using DG.Tweening;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PokerChip : MonoBehaviour
{
    public Image image;
    public Vector3 pokerChipDestination;
    public float appearColorSpeed;
    public float appearMoveSpeed;
    public float moveSpeed;
    
    private void Start()
    {
        image.color = new Color(1f, 1f, 1f, 0f);
    }

    private void Update()
    {
        
    }

    public void StartAnim()
    {
        image.color = new Color(1f, 1f, 1f, 0f);
        image.DOFade(1f, appearColorSpeed);

        Sequence seq = DOTween.Sequence();

            transform.localScale = Vector3.zero;
            
        seq.Append(transform.DOMove(transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized * Random.value,
            appearMoveSpeed).SetEase(Ease.OutQuart));
        seq.Join(transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), appearMoveSpeed).SetEase(Ease.OutQuart));
        seq.Append(transform.DOMove(pokerChipDestination, appearColorSpeed).SetEase(Ease.Linear));
        seq.OnComplete(() =>
        {
            MoneyManager.instance.AddMoney(1);
            
            image.color = new Color(1f, 1f, 1f, 0f);
            PokerChipPool.instance.SendToPokerPool(this);
        });
    }
}
