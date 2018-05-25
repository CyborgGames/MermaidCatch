using UnityEngine;

public class Boundary : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<Ball>() != null) {
			// Score a point
			if (other.transform.position.x > 6f) {
				GameManager.Instance.ScoreRed();
			} else if (other.transform.position.x < -6f) {
				GameManager.Instance.ScoreBlue();
			}
			Destroy(other.gameObject);
			BallSpawner.NumberOfBalls--;
		}
	}
}
