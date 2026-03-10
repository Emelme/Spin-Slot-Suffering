using System;
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

    public bool isSlot;
    public bool isShop;
    public bool isUpgrade;
    
    public GameObject slotUI;
    public GameObject shopUI;
    public GameObject upgradeUI;

    private void Start()
    {
        isSlot = true;
        isShop = false;
        isUpgrade = false;
        
        slotUI.SetActive(isSlot);
        shopUI.SetActive(!isSlot);
        upgradeUI.SetActive(!isSlot);
        
        camera.transform.position = new Vector3(0f, 0f, -10f);
    }

    public void ChangeSlot()
    {
        isSlot = true;
        isShop = false;
        isUpgrade = false;
        
        slotUI.SetActive(isSlot);
        shopUI.SetActive(!isSlot);
        upgradeUI.SetActive(!isSlot);
        
        StartCoroutine(ChangeScene());
    }

    public void ChangeShop()
    {
        isShop = true;
        isSlot = false;
        isUpgrade = false;
        
        shopUI.SetActive(isShop);
        slotUI.SetActive(!isShop);
        upgradeUI.SetActive(!isShop);
        
        StartCoroutine(ChangeScene());
    }

    public void ChangeUpgrade()
    {
        isUpgrade = true;
        isSlot = false;
        isShop = false;
        
        upgradeUI.SetActive(isUpgrade);
        shopUI.SetActive(!isUpgrade);
        slotUI.SetActive(!isUpgrade);

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
