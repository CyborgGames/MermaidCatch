using UnityEngine;
using UnityEngine.UI;

using Cyborg.Audio;
using Cyborg.Scenes;

namespace MermaidCatch {
	
	public class ScoreUI : MonoBehaviour {
		
		public ScoreTracker blue, red;

		void OnEnable() {
			UIEvents.OnStartGame += ResetScore;
			UIEvents.OnScore += Score;

			SceneController.AfterSceneUnload += Hide;
			SceneController.BeforeSceneLoad += Show;
		}

		void OnDisable() {
			UIEvents.OnStartGame -= ResetScore;
			UIEvents.OnScore -= Score;

			SceneController.AfterSceneUnload -= Hide;
			SceneController.BeforeSceneLoad -= Show;
		}

		public void Show() {
			if (GameManager.IsMenu) {
				// Do nothing; this is the main menu;
				Hide();
			} else {
				GetComponent<Canvas>().enabled = true;
			}
		}

		public void Hide() {
			GetComponent<Canvas>().enabled = false;
		}
		
		public void ResetScore() {			
			// Update the UI
			blue.Reset();
			red.Reset();			
		}
		
		void Score(PlayerEnum player) {
			if (player == PlayerEnum.Red) {
				// Blue loses a life when red scores
				blue.Decrease();
			} else {
				// Red loses a life when Blue scores
				red.Decrease();
			}			
		}		

	}
	
}
