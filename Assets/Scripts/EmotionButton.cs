using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Config;

public class EmotionButton : MonoBehaviour
{
	public PlayerAction playerAction;

	public TMP_Text text;

	public void Initialize(PlayerAction action)
	{
		playerAction = action;
		text.text = action.name;
	}

	public void ButtonPress()
	{
		GameManager.Instance.actionsSystem.PlayerInputAction(playerAction);
	}
}
