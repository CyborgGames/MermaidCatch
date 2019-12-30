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
		}

		void OnDisable() {
			UIEvents.OnStartGame -= ResetScore;
			UIEvents.OnScore -= Score;
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
