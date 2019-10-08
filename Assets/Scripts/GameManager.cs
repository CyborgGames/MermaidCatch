using UnityEngine;

namespace MermaidCatch {

	public class GameManager : Singleton<GameManager> {

		void OnEnable() {
			UIEvents.OnStartGame += UnPause;
		}

		void OnDisable() {
			UIEvents.OnStartGame -= UnPause;
		}

		void Update () {
			
			// Pauses or plays game when player hits p
			if (PressedPause()) {
				Time.timeScale = IsPaused() ? 1 : 0;
			} 
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
