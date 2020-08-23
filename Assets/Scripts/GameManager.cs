using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config;

public class GameManager
{

	private static readonly GameManager instance = new GameManager();

	public static GameManager Instance
	{
		get { return instance; }
	}

	protected GameManager() { }

	// ########

	public ActionsSystem actionsSystem;

	public string currentEmotionID;
	public Dictionary<string, CatEmotion> dictEmotions;

	public CatEmotion GetCurrentEmotion()
	{
		return dictEmotions[currentEmotionID];
	}

	public void FillEmoDictionary(EmotionSystem emoSystem)
	{
		dictEmotions = new Dictionary<string, CatEmotion>();

		foreach (var emotion in emoSystem.emotions)
		{
			if (dictEmotions.ContainsKey(emotion.ID))
			{
				Debug.LogError("DUPLICATE EMOTION : " + emotion.ID);
			}
			else
			{
				dictEmotions.Add(emotion.ID, emotion);

				if (currentEmotionID == null)
					currentEmotionID = emotion.ID;
			}
		}

		// full validation

		foreach (KeyValuePair<string, CatEmotion> emotion in dictEmotions)
		{
			foreach (PlayerAction action in emotion.Value.actions)
			{
				if (!dictEmotions.ContainsKey(action.targetEmotionID))
				{
					Debug.LogError("INCORRECT TARGET ID : " + emotion.Value.name + " : " + action.name + " : " + action.targetEmotionID);
				}
			}
		}
	}
}
