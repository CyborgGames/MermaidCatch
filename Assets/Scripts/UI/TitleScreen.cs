using UnityEngine;

namespace MermaidCatch {

	public class TitleScreen : Singleton<TitleScreen> {
		
		public void StartSinglePlayer() {
			SceneController.Instance.SwitchScene("SinglePlayer");
			GameManager.Instance.SetupGame();
		}
		
		public void StartMultiPlayer() {
			SceneController.Instance.SwitchScene("MultiPlayer");
			GameManager.Instance.SetupGame();
		}
		
		public void ShowTitleScreen() {
			gameObject.SetActive(true);
		}
		
		void HideTitleScreen() {
			gameObject.SetActive(false);
		}
	}

}
