using UnityEngine;

using Cyborg.Scenes;

namespace MermaidCatch {

	public class TitleScreen : MonoBehaviour {

		// Start a new single player game
		public void StartSinglePlayer() {
			AudioController.PlayClick();
			SceneEvents.ChangeScene("SinglePlayer");
			UIEvents.StartGame();

		}

		// Start a new multiplayer game
		public void StartMultiPlayer() {
			AudioController.PlayClick();			
			SceneEvents.ChangeScene("MultiPlayer");
			UIEvents.StartGame();			
		} 

		// Also start when pressing Space
		void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				StartSinglePlayer();
			}
		}
	}

}
