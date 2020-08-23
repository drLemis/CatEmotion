using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Config
{
	[Serializable]
	public class CatEmotion
	{
		public string ID;
		public string name;
		public Sprite icon;
		public List<PlayerAction> actions;
	}

	[Serializable]
	public struct PlayerAction
	{
		public string name;
		public string targetEmotionID;
		public string description;
	}
}