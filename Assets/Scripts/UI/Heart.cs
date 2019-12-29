using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MermaidCatch {

	// A heart representing one of the player's lives
	public class Heart : MonoBehaviour
	{
		// The image representing the heart
		Image img;

		// True if the heart is fading out; false otherwise
		bool isAnimating = false;

		// Duration of the fadeout
		float duration = 1.5f;

		// Gain this heart
		public void Gain() {
			img.color = Color.white;
			isAnimating = false;
		}

		// Lose this heart
		public void Lose() {
			// Trigger a fadeout
			isAnimating = true;
		}
		
		void Awake() {
			img = GetComponent<Image>();
		}
		
		void Update() {
			if (isAnimating) {
				FadeOut();
			}	   		
		}

		void FadeOut() {
			img.color = Color.Lerp(img.color, Color.clear, Time.deltaTime * duration);
			if (img.color == Color.clear) {
				isAnimating = false;
			}	
		}
		
	}
}
