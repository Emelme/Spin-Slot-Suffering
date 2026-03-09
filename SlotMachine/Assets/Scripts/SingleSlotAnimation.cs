using System.Collections;
using UnityEngine;

public class SingleSlotAnimation : MonoBehaviour
{
    public SpriteRenderer sr;
    
    public Sprite bananaSprite;
    public Sprite cherrySprite;
    public Sprite cleverSprite;
    public Sprite sevenSprite;

    public Sprite[] moutionSprites;
    public float moutionSpeed;

    private void Update()
    {
    }
        
    public void StartMotionAnimation()
    {
        StartCoroutine(AnimateSprite());
    }

    public void StopMotionAnimation(SingleSlotType slotType)
    {
        StopAllCoroutines();
        SetSlotSprite(slotType);
    }

    private IEnumerator AnimateSprite()
    {
        while (true)
        {
            sr.sprite = moutionSprites[Random.Range(0, moutionSprites.Length)];
            
            yield return new WaitForSeconds(moutionSpeed);
        }
    }
    
    public void SetSlotSprite(SingleSlotType slotType)
    {
        switch (slotType)
        {
            case SingleSlotType.banana:
                sr.sprite = bananaSprite;
                break;
            case SingleSlotType.cherry:
                sr.sprite = cherrySprite;
                break;
            case SingleSlotType.clever:
                sr.sprite = cleverSprite;
                break;
            case SingleSlotType.seven:
                sr.sprite = sevenSprite;
                break;
            default:
                break;
        }
    }
}

public enum SingleSlotType
{
    banana,
    cherry,
    clever,
    seven,
}
