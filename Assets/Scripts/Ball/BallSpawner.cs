using UnityEngine;
using System.Collections;

namespace MermaidCatch {
	public class BallSpawner : MonoBehaviour {
		
		public static int NumberOfBalls { get; set; }
		public GameObject _ball;
		
		bool spawningBall = false;	
		
		const float MAX_BALLS = 3;
		
		private static Ball[] balls;

		void OnEnable() {
			UIEvents.OnStartGame += Reset;
		}

		void OnDisable() {
			UIEvents.OnStartGame -= Reset;
		}
		
		void FixedUpdate () {
			if (NumberOfBalls < MAX_BALLS && !spawningBall) {
				StartCoroutine(SpawnBallWithDelay());
			}
		}
		
		// Destroy all balls in the game
		public static void Reset() {
			balls = GameObject.FindObjectsOfType<Ball>();
			
			// Destroy all balls
			foreach (Ball ball in balls) {
				Destroy(ball.gameObject);
			}
			
			// Reset the number of balls
			NumberOfBalls = 0;
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

}
