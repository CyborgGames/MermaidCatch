using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Audio;

namespace MermaidCatch {

	public class AudioController : MonoBehaviour
	{

		public static void Pause() {
			AudioEvents.Pause();
		}

		public static void UnPause() {
			AudioEvents.UnPause();
		}

		public static void Restart() {
			AudioEvents.Restart();
		}
		
		public static void PlayWin() {		
			AudioEvents.PlaySound("win");			
		}

		public static void PlayLose() {		
			AudioEvents.PlaySound("lose");
		}
		
		public static void PlayPlop() {
			AudioEvents.PlaySound("plop");
		}

		public static void PlayClick() {
			AudioEvents.PlaySound("misc_menu");
		}
	}
	
}
