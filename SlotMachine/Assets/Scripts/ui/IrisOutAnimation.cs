using UnityEngine;
using DG.Tweening;

public class IrisOutAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private float duration;
    [SerializeField] private float delay;

    private void Start()
    {
        PlayIrisOut();
    }

    private void GameManager_OnSceneLoading()
    {
        PlayIrisIn();
    }

    private void PlayIrisOut()
    {
        rectTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(delay);
        
        seq.AppendCallback(() =>
        {
            Vector2 middlePoint = Vector3.zero;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(middlePoint);
            rectTransform.position = screenPos;
        });

        seq.Append(rectTransform.DOScale(2000f, duration).SetEase(Ease.Linear));
    }

    private void PlayIrisIn()
    {
        rectTransform.localScale = new Vector3(2000, 2000, 2000);

        Vector2 middlePoint = Vector3.zero;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(middlePoint);
        rectTransform.position = screenPos;

        //rectTransform.DOScale(0.1f, duration).SetEase(Ease.Linear).OnComplete(() => GameManager.Instance.isReadyToSwithTheScene = true);
    }
}