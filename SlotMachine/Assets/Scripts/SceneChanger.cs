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
		SetState(true, false, false);
		camera.transform.position = new Vector3(0f, 0f, -10f);
	}

	public void ChangeSlot()
	{
		StartCoroutine(ChangeScene(true, false, false));
	}

	public void ChangeShop()
	{
		StartCoroutine(ChangeScene(false, true, false));
	}

	public void ChangeUpgrade()
	{
		StartCoroutine(ChangeScene(false, false, true));
	}

	private IEnumerator ChangeScene(bool slot, bool shop, bool upgrade)
	{
		// Fade to black
		yield return fadeImage.DOFade(1f, changeTime).WaitForCompletion();

		// Apply state
		SetState(slot, shop, upgrade);

		// Move camera
		camera.transform.position = scene;

		// Fade back
		yield return fadeImage.DOFade(0f, changeTime).WaitForCompletion();
	}

	private void SetState(bool slot, bool shop, bool upgrade)
	{
		isSlot = slot;
		isShop = shop;
		isUpgrade = upgrade;

		slotUI.SetActive(isSlot);
		shopUI.SetActive(isShop);
		upgradeUI.SetActive(isUpgrade);
	}
}
