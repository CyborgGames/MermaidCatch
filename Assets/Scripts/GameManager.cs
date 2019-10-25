using System.Collections;
using UnityEngine;

namespace MermaidCatch {

	public class GameManager : Singleton<GameManager> {
		
		public bool IsMenu = true;
		
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

		void Reset() {
			BallSpawner.Reset();
			UnPause();
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

		void GameOver() {
			StartCoroutine(ToMainMenu());
		}

		IEnumerator ToMainMenu() {
			AudioController.Pause();

			IsMenu = true;
			yield return new WaitForSeconds(0.25f);

			Debug.Log("Switching scene to Title");
			SceneController.Instance.SwitchScene("Title");

			yield return new WaitForSeconds(1.5f);
			AudioController.Restart();
		}

		
		// Returns true if the player pressed the Pause button or key
		private bool PressedPause() {
			return Input.GetKeyDown(KeyCode.P);
		}
		
		private bool IsPaused() {
			return Time.timeScale == 0;
		}
		
	}

}
