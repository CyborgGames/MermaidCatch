using System;
using System.Collections;
using UnityEngine;

namespace MermaidCatch {
    
    // Spawn point that spawns balls
    public class BallSpawner : SpawnPoint {
	
	// Number of balls currently in play
	public static int NumberOfBalls { get; set; }
	
	// Max number of balls that can be in play
	public int MaxBalls = 3;
	
	// Ball prefab to spawn
	public Ball ballPrefab;	  
	
	void Start() {
	    Reset();
	}
		
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
	    // Debug.Log("BallSpawner.NumberOfBalls = " + NumberOfBalls);
	    if (GameManager.IsMenu) {
		// Don't spawn on the menu scene
	    } else if (isSpawning) {
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
	    isSpawning = true;
	    
	    yield return new WaitForSeconds (Delay);
	    
	    SpawnBall();
	    
	    isSpawning = false;
	}
	
	void SpawnBall() {
	    NumberOfBalls++;
	    
	    Instantiate(ballPrefab, GetSpawnPosition(), GetSpawnRotation(), transform);
	}
	
    }
    
}
