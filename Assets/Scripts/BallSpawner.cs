using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

	public static int NumberOfBalls { get; set; }
	public GameObject _ball;

	bool spawningBall = false;

	void FixedUpdate () {
		if (NumberOfBalls < 3 && !spawningBall) {
			StartCoroutine(SpawnBallWithDelay());
		}
	}

	public static void Reset() {
		NumberOfBalls = 0;
		foreach (Ball ball in GameObject.FindObjectsOfType<Ball>()) {
			Destroy(ball.gameObject);
		}
	}

	IEnumerator SpawnBallWithDelay() {
		spawningBall = true;
		float delay = Random.Range(0.5f, 2f);
		yield return new WaitForSeconds (delay);
		SpawnBall();
		spawningBall = false;

	}

	void SpawnBall() {
		NumberOfBalls++;
		GameObject ballClone = Instantiate(_ball, 
			transform.position, 
			transform.rotation);
		ballClone.transform.SetParent(transform);
		ballClone.GetComponent<Ball>().Push();
	}

}
