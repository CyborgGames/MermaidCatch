using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

namespace MermaidCatch {

	// Manages UI events
	public class UIEvents : MonoBehaviour
	{

		public static event Action OnStartGame;

		public delegate void PlayerEvent(PlayerEnum player);
		public static event PlayerEvent OnScore;
		
		// Start a new game
		public static void StartGame() {
			if (OnStartGame != null) {
				OnStartGame();
			}
		}

		// Score one point to Blue
		public static void ScoreBlue() {		  
			if (OnScore != null) {
				OnScore(PlayerEnum.Blue);
			}
		}

		// Score one point to Red
		public static void ScoreRed() {
			if (OnScore != null) {
				OnScore(PlayerEnum.Red);
			}
		}
	}
	
}
