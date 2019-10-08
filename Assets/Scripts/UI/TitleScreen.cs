using UnityEngine;

namespace MermaidCatch {

	public class TitleScreen : Singleton<TitleScreen> {
		
		public void StartSinglePlayer() {
			AudioEvents.PlaySound("misc_menu");
			SceneController.Instance.SwitchScene("SinglePlayer");
			UIEvents.StartGame();

		}
		
		public void StartMultiPlayer() {
			AudioEvents.PlaySound("misc_menu");
			SceneController.Instance.SwitchScene("MultiPlayer");
			UIEvents.StartGame();			
		}
		
		
	}

}
