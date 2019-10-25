using UnityEngine;

namespace MermaidCatch {

	public class TitleScreen : Singleton<TitleScreen> {
		
		public void StartSinglePlayer() {
			AudioController.PlayClick();
			SceneController.Instance.SwitchScene("SinglePlayer");
			UIEvents.StartGame();

		}
		
		public void StartMultiPlayer() {
			AudioController.PlayClick();
			
			SceneController.Instance.SwitchScene("MultiPlayer");
			UIEvents.StartGame();			
		} 
		
		void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				StartSinglePlayer();
			}
		}
	}

}
