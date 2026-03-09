using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject camera;

    public Image fadeImage;
    
    public float changeTime;
    
    public Vector3 scene;

    public void StartChangeCoroutine()
    {
        
        Debug.Log("StartChangeCoroutine");
        StartCoroutine(ChangeScene());
    }
    
    private IEnumerator ChangeScene()
    {
        fadeImage.DOFade(1f, changeTime);
        yield return new WaitForSeconds(changeTime);
        
        camera.transform.position = scene;
        
        fadeImage.DOFade(0f, changeTime);
    }
}
