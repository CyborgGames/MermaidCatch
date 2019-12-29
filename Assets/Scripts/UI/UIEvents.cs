using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

namespace MermaidCatch {

	// Manages UI events
	public class UIEvents : MonoBehaviour
	{

		public static event Action OnStartGame;

		// TODO: Make Generic
		public static event Action OnScoreBlue;
		public static event Action OnScoreRed;
		
		// Start a new game
		public static void StartGame() {
			if (OnStartGame != null) {
				OnStartGame();
			}
		}

		// Score one point to Blue
		public static void ScoreBlue() {
			if (OnScoreBlue != null) {
				OnScoreBlue();
			}
		}

		// Score one point to Red
		public static void ScoreRed() {
			if (OnScoreRed != null) {
				OnScoreRed();
			}
		}
	}
	
}
