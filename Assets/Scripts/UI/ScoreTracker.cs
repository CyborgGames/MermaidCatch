using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {

	// UI widget that keeps track of the player's lives
	public class ScoreTracker : MonoBehaviour
	{
		// An array of hearts, representing the player's life
		Heart[] hearts;
		
		// Indext to keep track of the next heart to lose if the player takes damage
		int i;
		
		void Start() {
			// Initialize the array of Hearts
			hearts = gameObject.GetComponentsInChildren<Heart>();

			// Reset the score
			Reset();
		}

		// Reset the score by gaining up to the max number of hearts
		public void Reset() {
			Array.ForEach(hearts, heart => heart.Gain());		
			i = hearts.Length;
		}

		// Decrease the score by removing a heart
		public void Decrease() {
			if (i > 0) {
				i--;
				
				hearts[i].Lose();
			}
		}
	}
}
