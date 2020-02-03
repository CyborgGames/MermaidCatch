using System.Collections;
using UnityEngine;

using Cyborg.Scenes;

namespace MermaidCatch {
    
    public class GameManager : Singleton<GameManager> {
	
	public static bool IsMenu = true;
	
	void OnEnable() {
	    UIEvents.OnStartGame += Reset;
	}
	
	void OnDisable() {
	    UIEvents.OnStartGame -= Reset;
	}
	
	void Update () {
	    HandleKeyboardInput();	    
	}
	
	public static void Win() {
	    AudioController.PlayWin();
	    
	    SceneEvents.ChangeScene("_Win");
	    
	    Instance.GameOver();
	}
	
	public static void Lose() {
	    AudioController.PlayLose();
	    
	    SceneEvents.ChangeScene("_Lose");
	    
	    Instance.GameOver();
	}

	public void UnPause() {
	    Time.timeScale = 1;
	}
	
	public void Pause() {
	    Time.timeScale = 0;
	}
	
	void Reset() {
	    IsMenu = false;
	    UnPause();
	}
	
	void GameOver() {
	    StartCoroutine(ToMainMenu());
	}
	
	void HandleKeyboardInput() {
	    // Pauses or plays game when player hits p
	    if (PressedPause()) {
		Time.timeScale = IsPaused() ? 1 : 0;
		UIEvents.Pause();
	    }
	}
	
	IEnumerator ToMainMenu() {
	    
	    IsMenu = true;
	    
	    // AudioController.Pause();
	    
	    yield return new WaitForSeconds(3.0f);			
	    
	    SceneEvents.ChangeScene("Title");
	    
	    yield return new WaitForSeconds(1.5f);
	    
	    // AudioController.Restart();
	}
	
	
	// Returns true if the player pressed the Pause button or key
	bool PressedPause() {
	    return Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Pause);
	}
	
	bool PressedQuit() {
	    return Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape);
	}
	
	bool IsPaused() {
	    return Time.timeScale == 0;
	}
	
    }

}
