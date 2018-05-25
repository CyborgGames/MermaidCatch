using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : Singleton<ScoreUI> {

	public Text BlueScore { get; set; }
	public Text RedScore { get; set; }
	public Text GameOverText { get; set; }

	static int blueScore, redScore;

	void Awake() {
		BlueScore = GameObject.Find("Blue Score").GetComponent<Text>();
		RedScore = GameObject.Find("Red Score").GetComponent<Text>();
		GameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
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
		redScore++;
		RedScore.text = redScore.ToString();
		if (redScore >= 5) {
			RedWins();
		}
	}

	public void ScoreBlue() {
		blueScore++;
		BlueScore.text = blueScore.ToString();
		if (blueScore >= 5) {
			BlueWins();
		}
	}

	public void BlueWins() {
		GameOverText.gameObject.SetActive(true);
		GameOverText.text = "Blue player wins!";
		GameManager.Instance.Pause();
		TitleScreen.Instance.ShowTitleScreen();

	}

	public void RedWins() {
		GameOverText.gameObject.SetActive(true);
		GameOverText.text = "Red player wins!";
		GameManager.Instance.Pause();
		TitleScreen.Instance.ShowTitleScreen();
	}
}
