using UnityEngine;
using System.Collections;

namespace MermaidCatch {
	public class BallSpawner : MonoBehaviour {
		
		public static int NumberOfBalls { get; set; }
		public GameObject _ball;
		public int MaxBalls = 3;

		public float MaxDelay = 2f;
		public float MinDelay = 0.5f;
		
		bool spawningBall = false;	
				
		private static Ball[] balls;
		
		void FixedUpdate () {
			if (NumberOfBalls < MaxBalls && !spawningBall && !GameManager.Instance.IsMenu) {
				StartCoroutine(SpawnBallWithDelay());
				Debug.Log("Number of balls on screen: " + NumberOfBalls);
			}
		}
		
		// Destroy all balls in the game
		public static void Reset() {

			Debug.Log("Resetting the game.");
			
			balls = GameObject.FindObjectsOfType<Ball>();
			
			// Destroy all balls
			foreach (Ball ball in balls) {
				Destroy(ball.gameObject);
			}
			
			// Reset the number of balls
			NumberOfBalls = 0;

			GameManager.Instance.IsMenu = false;
		}
		
		IEnumerator SpawnBallWithDelay() {
			spawningBall = true;
			
			float delay = Random.Range(MinDelay, MaxDelay);
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
