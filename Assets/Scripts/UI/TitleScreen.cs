using UnityEngine;

using Cyborg.Scenes;

namespace MermaidCatch {

	public class TitleScreen : Singleton<TitleScreen> {
		
		public void StartSinglePlayer() {
			AudioController.PlayClick();
			SceneEvents.ChangeScene("SinglePlayer");
			UIEvents.StartGame();

		}
		
		public void StartMultiPlayer() {
			AudioController.PlayClick();
			
			SceneEvents.ChangeScene("MultiPlayer");
			UIEvents.StartGame();			
		} 
		
		void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				StartSinglePlayer();
			}
		}
	}

}
