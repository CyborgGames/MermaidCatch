using UnityEngine;
using UnityEngine.UI;

namespace MermaidCatch {

	
	public class ScoreUI : Singleton<ScoreUI> {
		
		public Text GameOverText;
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
			
			GameOverText.text = "";
			GameOverText.gameObject.SetActive(false);
			
		}
		
		public void ScoreRed() {
			redScore = ScorePlayer("Red Player", redScore, blue);
		}
		
		public void ScoreBlue() {
			blueScore = ScorePlayer("Blue Player", blueScore, red);
		}
		
		public int ScorePlayer(string playerName, int score, ScoreTracker tracker) {
			score++;

			// TODO: Update lives
			tracker.Decrease();
			
			if (score == SCORE_NEEDED_TO_WIN) {
				PlayerWins(playerName);
			}
			return score;
		}
    
		public void BlueWins() {
			PlayerWins("Blue Player");
		}
		
		public void RedWins() {
			PlayerWins("Red Player");
		}
		
		void PlayerWins(string playerName) {
			GameOverText.gameObject.SetActive(true);
			GameOverText.text = string.Format("{0} wins!", playerName);
			
			GameManager.Instance.IsMenu = true;
			
			Debug.Log("Switching scene to Title");
			SceneController.Instance.SwitchScene("Title");

			Hide();
			
		}
	}
	
}
