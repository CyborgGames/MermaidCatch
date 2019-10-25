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
		
		public void UnPause() {
			Time.timeScale = 1;
		}
    
		public void Pause() {
			Time.timeScale = 0;
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
