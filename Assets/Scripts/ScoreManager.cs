using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {

    public class ScoreManager : MonoBehaviour
    {
	
	static Score score;		
	public int Max = 3;
	
	void OnEnable() {
	    UIEvents.OnStartGame += ResetScore;
	    UIEvents.OnScore += Score;
	}
	
	void OnDisable() {
	    UIEvents.OnStartGame -= ResetScore;
	    UIEvents.OnScore -= Score;
	}
	
	void Start() {
	    score = new Score();
	}
	
	// Reset the score to 0
	void ResetScore() {
	    score.Reset();			
	}
	
	// Score a point for the given player
	void Score(PlayerEnum player) {
	    AudioController.PlayClick();
	    
	    score.Increment(player);
	    
	    if (score.GetScore(player) == Max) {
		PlayerWins(player);
	    }			
	}
	
	void PlayerWins(PlayerEnum player) {			
	    if (player == PlayerEnum.Red) {
		// Red is the player; so this is a win
		GameManager.Win();
	    } else {
		// Blue is the opponent; so this is a loss
		GameManager.Lose();
	    }			
	}
    }
    
}
