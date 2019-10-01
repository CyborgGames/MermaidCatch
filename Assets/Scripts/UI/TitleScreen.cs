using UnityEngine;

public class TitleScreen : Singleton<TitleScreen> {

    public void StartSinglePlayer() {
	HideTitleScreen();
	GameManager.Instance.StartNewSinglePlayerGame();
    }
    
    public void StartMultiPlayer() {
	HideTitleScreen();
	GameManager.Instance.StartNewMultiplayerGame();
    }
    
    public void ShowTitleScreen() {
	gameObject.SetActive(true);
    }
    
    void HideTitleScreen() {
	gameObject.SetActive(false);
    }
}
