using UnityEngine;

namespace MermaidCatch {
	
    // Boundaries marking the edge of the screen
    public class Boundary : MonoBehaviour {

	public PlayerEnum player;
	
	// Min and max coordinates of the game
	const float MAX = 4f;
	const float MIN = -4f;
	
	void OnTriggerEnter2D (Collider2D other) {
	    if (other.GetComponent<Ball>() != null && !GameManager.IsMenu) {
		
		ScorePoint();
				
		// Destroy the ball 
		Destroy(other.gameObject);

		// Clean up the count in BallSpawner
		BallSpawner.NumberOfBalls--;
	    }
	}
	
	// Score a point for the given player
	void ScorePoint() {
	    UIEvents.Score(player);
	}	
    }
    
}
