using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

namespace MermaidCatch {
	public class UIEvents : MonoBehaviour
	{

		public static event Action OnStartGame;

		// TODO: Make Generic
		public static event Action OnScoreBlue;
		public static event Action OnScoreRed;

		
		public static void StartGame() {
			if (OnStartGame != null) {
				OnStartGame();
			}
		}

		
		public static void ScoreBlue() {
			if (OnScoreBlue != null) {
				OnScoreBlue();
			}
		}
		
		public static void ScoreRed() {
			if (OnScoreRed != null) {
				OnScoreRed();
			}
		}
	}
	
}
