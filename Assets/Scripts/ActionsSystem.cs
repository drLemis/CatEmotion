using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Config;

public class ActionsSystem : MonoBehaviour
{
	[SerializeField]
	private Transform buttonsOrigin;
	[SerializeField]
	private GameObject buttonPrefab;
	[SerializeField]
	private TMP_Text emotionText;
	[SerializeField]
	private Image emotionIcon;
	[SerializeField]
	private TMP_Text catReactionText;

	private void Awake()
	{
		GameManager.Instance.actionsSystem = this;

		SyncInfo();
		SpawnButtons();
	}

	private void SyncInfo(string description = "")
	{
		catReactionText.text = description;
		emotionText.text = GameManager.Instance.GetCurrentEmotion().name;
		emotionIcon.sprite = GameManager.Instance.GetCurrentEmotion().icon;
	}

	private void SpawnButtons()
	{
		foreach (Transform child in buttonsOrigin)
		{
			GameObject.Destroy(child.gameObject);
		}

		foreach (PlayerAction i in GameManager.Instance.GetCurrentEmotion().actions)
		{
			GameObject spawnedButton = Instantiate(buttonPrefab, buttonsOrigin);
			spawnedButton.GetComponent<EmotionButton>().Initialize(i);
		}
	}

	public void PlayerInputAction(PlayerAction action)
	{
		if (!GameManager.Instance.dictEmotions.ContainsKey(action.targetEmotionID))
		{
			Debug.LogError("INCORRECT TARGET ID : " + action.name + " : " + action.targetEmotionID);
			return;
		}

		GameManager.Instance.currentEmotionID = GameManager.Instance.dictEmotions[action.targetEmotionID].ID;

		SyncInfo(action.description);
		SpawnButtons();
	}
}
