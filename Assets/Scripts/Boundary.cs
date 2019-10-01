using UnityEngine;

// Boundaries marking the edge of the screen
public class Boundary : MonoBehaviour {

    // Min and max coordinates of the game
    const float MAX = 6f;
    const float MIN = -6f;

    void OnTriggerEnter2D (Collider2D other) {
	if (other.GetComponent<Ball>() != null) {
	    
	    ScorePoint(other.transform);

	    // Destory the ball and clean up the count in BallSpawner
	    Destroy(other.gameObject);
	    BallSpawner.NumberOfBalls--;
	}
    }

    // Score a point for the player on the opposite side of the boundary
    // TODO: Make generic
    void ScorePoint(Transform ball) {
	// Score a point
	if (ball.position.x > MAX) {
	    GameManager.Instance.ScoreRed();
	} else if (ball.position.x < MIN) {
	    GameManager.Instance.ScoreBlue();
	}	
    }
	
}
