using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Scenes;

namespace MermaidCatch {

	// Hide when on the title screen
	public class ControlsUI : MonoBehaviour
	{

		void OnEnable() {
			SceneController.AfterSceneUnload += Hide;
			SceneController.BeforeSceneLoad += Show;
		}

		void OnDisable() {
			SceneController.AfterSceneUnload -= Hide;
			SceneController.BeforeSceneLoad -= Show;
		}

		void Show() {
			if (GameManager.IsMenu) {
				Hide();
			} else {
				GetComponent<Canvas>().enabled = true;
			}
		}

		void Hide() {
			GetComponent<Canvas>().enabled = false;
		}
	}
	
}
