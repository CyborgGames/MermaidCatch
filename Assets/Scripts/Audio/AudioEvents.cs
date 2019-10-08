using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {
	public class AudioEvents : MonoBehaviour
	{

		public delegate void PlaySoundHandler(string soundClipName);
		public static event PlaySoundHandler OnPlayMusic;
		public static event PlaySoundHandler OnPlaySound;
		
		public static void PlayMusic(string clipName) {
			if (OnPlayMusic != null) {
				OnPlayMusic(clipName);
			}
		}

		public static void PlaySound(string clipName) {
			if (OnPlaySound != null) {
				OnPlaySound(clipName);
			}
		}

	}

}
