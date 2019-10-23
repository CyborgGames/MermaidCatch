using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Audio;

namespace MermaidCatch {

	public class AudioController : MonoBehaviour
	{

		public static void PlayPlop() {
			AudioEvents.PlaySound("plop");
		}

		public static void PlayClick() {
			AudioEvents.PlaySound("misc_menu");
		}
	}
	
}
