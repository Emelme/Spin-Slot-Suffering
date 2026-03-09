using Febucci.TextAnimatorForUnity.TextMeshPro;
using UnityEngine;

public class CopyText : MonoBehaviour
{
    public TextAnimator_TMP textAnim;
    public TextAnimator_TMP textToCopy;
    
    private void Update()
    {
        textAnim.SetText(textToCopy.textFull);
    }
}
