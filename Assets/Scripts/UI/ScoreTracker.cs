using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
	// An array of hearts, representing the player's life
	Heart[] hearts;

	// Indext to keep track of the next heart to lose if the player takes damage
	int i;

	void Start() {
		hearts = gameObject.GetComponentsInChildren<Heart>();
		Reset();
	}
	
	public void Reset() {
		Array.ForEach(hearts, heart => heart.Gain());		
		i = hearts.Length;
	}

	public void Decrease() {
		if (i > 0) {
			i--;
			
			hearts[i].Lose();
		}
	}
	
}
