using UnityEngine;
using UnityEngine.UI;

namespace MermaidCatch {
	
	public class ScoreUI : Singleton<ScoreUI> {
		
		public Text BlueScore;
		public Text RedScore;
		public Text GameOverText;
		
		static int blueScore, redScore;
		
		const int SCORE_NEEDED_TO_WIN = 5;

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
		
		public void ResetScore() {
			blueScore = 0;
			redScore = 0;
			
			BlueScore.text = blueScore.ToString();
			RedScore.text = redScore.ToString();
			
			GameOverText.text = "";
			GameOverText.gameObject.SetActive(false);
			
		}
		
		public void ScoreRed() {
			redScore = ScorePlayer("Red Player", redScore, RedScore);
		}
		
		public void ScoreBlue() {
			blueScore = ScorePlayer("Blue Player", blueScore, BlueScore);
		}
		
		public int ScorePlayer(string playerName, int score, Text scoreLabel) {
			score++;
			scoreLabel.text = score.ToString();
			if (score >= SCORE_NEEDED_TO_WIN) {
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
			GameManager.Instance.Pause();
			TitleScreen.Instance.ShowTitleScreen();
		}
	}
	
}
