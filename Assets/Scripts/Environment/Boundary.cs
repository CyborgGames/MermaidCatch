using UnityEngine;

namespace MermaidCatch {
	
	// Boundaries marking the edge of the screen
	public class Boundary : MonoBehaviour {

		// Min and max coordinates of the game
		const float MAX = 4f;
		const float MIN = -4f;
		
		void OnTriggerEnter2D (Collider2D other) {
			if (other.GetComponent<Ball>() != null && !GameManager.IsMenu) {
				
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
				// If the ball's moving off the right side of the screen, score a point for red
				UIEvents.Score(PlayerEnum.Red);
			} else if (ball.position.x < MIN) {
				// If the ball's moving off the left side of the screen, score a point for blue
				UIEvents.Score(PlayerEnum.Blue);
			}	
		}
	
	}
	
}
