using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MermaidCatch {

	// Blink text back and forth
	public class Blink : MonoBehaviour
	{

		// The text to blink
		Text text;

		public float startDelay = 0.1f;
		public float interval = 1f;
		
		void Start() {
			text = GetComponent<Text>();
			InvokeRepeating("BlinkCycle", startDelay, interval);
		}
		
		void BlinkCycle() {
			text.enabled = !text.enabled;
		}
	}

}
