using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	private AsyncOperation asyncLoading;
	public Image loadingImage;

	[SerializeField]
	private EmotionSystem emoSystem;

	void Start()
	{
		GameManager.Instance.FillEmoDictionary(emoSystem);

		asyncLoading = SceneManager.LoadSceneAsync("Game");
	}

	void Update()
	{
		loadingImage.fillAmount = Mathf.Clamp01(asyncLoading.progress);
	}
}