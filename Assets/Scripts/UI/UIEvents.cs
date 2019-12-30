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

		public static event Action OnPause;
		
		// Start a new game
		public static void StartGame() {
			if (OnStartGame != null) {
				OnStartGame();
			}
		}

		public static void Score(PlayerEnum player) {
			if (OnScore != null) {
				OnScore(player);
			}	
		}

		// Toggle pause
		public static void Pause() {
			if (OnPause != null) {
				OnPause();
			}
		}

	}
	
}
