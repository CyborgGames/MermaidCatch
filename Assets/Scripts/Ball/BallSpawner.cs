using System;
using System.Collections;
using UnityEngine;

namespace MermaidCatch {

	// Spawn point that spawns balls
	public class BallSpawner : MonoBehaviour {

		// Number of balls currently in play
		public static int NumberOfBalls { get; set; }
		
		// Max number of balls that can be in play
		public int MaxBalls = 3;
	   
		// Ball prefab to spawn
		public GameObject ballPrefab;

		public float MaxDelay = 2f;
		public float MinDelay = 0.5f;
		
		bool spawningBall = false;				   

		void OnEnable() {
			UIEvents.OnStartGame += Reset;
		}

		void OnDisable() {
			UIEvents.OnStartGame -= Reset;
		}
		
		void FixedUpdate () {
			CheckForSpawnBall();
		}

		void CheckForSpawnBall() {
			if (GameManager.IsMenu) {
				// Don't spawn on the menu scene
			} else if (spawningBall) {
				// In the middle of spawning a ball; don't spawn anything new
			} else if (NumberOfBalls < MaxBalls) {
				// Go ahead and spawn
				StartCoroutine(SpawnBallWithDelay());
			}
		}
		
		// Destroy all balls in the game
		void Reset() {

			Ball[] balls = GameObject.FindObjectsOfType<Ball>();
			Array.ForEach(balls, ball => Destroy(ball.gameObject));
			NumberOfBalls = 0;
		}
		
		IEnumerator SpawnBallWithDelay() {
			spawningBall = true;

			yield return new WaitForSeconds (UnityEngine.Random.Range(MinDelay, MaxDelay));
			
			SpawnBall();		   
			spawningBall = false;
		}
		
		void SpawnBall() {
			NumberOfBalls++;
			
			GameObject ballClone = Instantiate(ballPrefab, 
											   transform.position, 
											   transform.rotation);
			
			ballClone.transform.SetParent(transform);

			// After spawning, give the ball a push
			ballClone.GetComponent<Ball>().Push();
		}
		
	}

}
