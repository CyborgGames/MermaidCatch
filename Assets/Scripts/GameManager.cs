using System.Collections;
using UnityEngine;

using Cyborg.Scenes;

namespace MermaidCatch {

	public class GameManager : Singleton<GameManager> {
		
		public static bool IsMenu = true;
		
		void OnEnable() {
			UIEvents.OnStartGame += Reset;
		}
		
		void OnDisable() {
			UIEvents.OnStartGame -= Reset;
		}

		void Update () {
			
			// Pauses or plays game when player hits p
			if (PressedPause()) {
				Time.timeScale = IsPaused() ? 1 : 0;
			} 
		}

		public static void Win() {
			AudioController.PlayWin();
			Instance.GameOver();
		}

		public static void Lose() {
			AudioController.PlayLose();
			Instance.GameOver();
		}

		public void UnPause() {
			Time.timeScale = 1;
		}
    
		public void Pause() {
			Time.timeScale = 0;
		}

		void Reset() {
			IsMenu = false;
			UnPause();
		}
		
		void GameOver() {
			StartCoroutine(ToMainMenu());
		}

		IEnumerator ToMainMenu() {
			AudioController.Pause();

			IsMenu = true;
			yield return new WaitForSeconds(0.25f);

			SceneEvents.ChangeScene("Title");

			yield return new WaitForSeconds(1.5f);
			
			AudioController.Restart();
		}

		
		// Returns true if the player pressed the Pause button or key
		bool PressedPause() {
			return Input.GetKeyDown(KeyCode.P);
		}
		
		bool IsPaused() {
			return Time.timeScale == 0;
		}
		
	}

}
