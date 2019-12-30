using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {

	public class PauseScreen : MonoBehaviour
	{

		Canvas canvas;
		
		void OnEnable() {
			UIEvents.OnPause += Toggle;
		}

		void OnDisable() {
			UIEvents.OnPause -= Toggle;
		}

		void Toggle() {
			if (GameManager.IsMenu) {
				// Do nothing; we're on the menu
			} else {
				canvas.enabled = !canvas.enabled;
			}
		}

		void Start() {
			canvas = GetComponent<Canvas>();
			canvas.enabled = false;
		}
	}
	
}
