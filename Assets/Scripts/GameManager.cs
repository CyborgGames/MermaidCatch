using UnityEngine;

public class GameManager : Singleton<GameManager> {

    public GameObject Arena { get; set; }
    public ScoreUI ScoreCanvas { get; set; }

    public GameObject Player2 { get; set; }

    void Start () {
	ScoreCanvas = GameObject.FindObjectOfType<ScoreUI>();
	Player2 = GameObject.Find("Player 2");

	Arena = GameObject.Find("Arena");
	Arena.SetActive(false);

	ScoreCanvas.gameObject.SetActive(false);
    }

    public void StartNewSinglePlayerGame() {
	 SetupGame();
	 Player2.GetComponent<Enemy>().enabled = true;
	 Player2.GetComponent<Player>().enabled = false;
     }

    public void StartNewMultiplayerGame() {
	SetupGame();
	Player2.GetComponent<Enemy>().enabled = false;
	Player2.GetComponent<Player>().enabled = true;
    }

    void Update () {

	// Pauses or plays game when player hits p
	if (PressedPause()) {
	    Time.timeScale = IsPaused() ? 1 : 0;
	} 
    }
    
    public void SetupGame() {
	Arena.SetActive(true);
	ScoreCanvas.gameObject.SetActive(true);
	ScoreCanvas.ResetScore();
	UnPause();
	
	// Destroy all balls
	BallSpawner.Reset();
    }
    
    public void HideArena() {
	Arena.SetActive(false);
    }
    
    public void ScoreRed() {
	ScoreCanvas.ScoreRed();
    }

    public void ScoreBlue() {
	ScoreCanvas.ScoreBlue();
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
