using UnityEngine;
using UnityEngine.UI;

namespace MermaidCatch {

	
	public class ScoreUI : Singleton<ScoreUI> {
		
		public ScoreTracker blue, red;
		
		static int blueScore, redScore;
		
		const int SCORE_NEEDED_TO_WIN = 3;

		void OnEnable() {
			UIEvents.OnStartGame += ResetScore;
			UIEvents.OnScoreRed += ScoreRed;
			UIEvents.OnScoreBlue += ScoreBlue;
		}

		void OnDisable() {
			UIEvents.OnStartGame -= ResetScore;
			UIEvents.OnScoreRed -= ScoreRed;
			UIEvents.OnScoreBlue -= ScoreBlue;
		}

		public void Show() {
			GetComponent<Canvas>().enabled = true;
		}

		public void Hide() {
			GetComponent<Canvas>().enabled = false;
		}
		
		public void ResetScore() {
			blueScore = 0;
			redScore = 0;

			// TODO: Update lives
			blue.Reset();
			red.Reset();
			
		}
		
		public void ScoreRed() {
			redScore = ScorePlayer("Red Player", redScore, blue);
		}
		
		public void ScoreBlue() {
			blueScore = ScorePlayer("Blue Player", blueScore, red);
		}
		
		public int ScorePlayer(string playerName, int score, ScoreTracker tracker) {
			score++;
	   
			tracker.Decrease();
			
			if (score == SCORE_NEEDED_TO_WIN) {
				PlayerWins(playerName);
			}
			return score;
		}
		
		void PlayerWins(string playerName) {			
			if (playerName == "red") {
				GameManager.Lose();
			} else {
				GameManager.Win();
			}


			
		}
	}
	
}
