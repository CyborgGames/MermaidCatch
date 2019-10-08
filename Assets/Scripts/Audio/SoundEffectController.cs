using UnityEngine;

namespace MermaidCatch {

	public class SoundEffectController : SoundController
	{

		// Bind events
		void OnEnable() {
			AudioEvents.OnPlaySound += PlayClip;
		}
		
		// Unbind events
		void OnDisable() {
			AudioEvents.OnPlaySound -= PlayClip;
		}

		public void PlayClip(string clipName) {
			AudioClip clip = GetClipByName(clipName);

			if (clip != null) {
				audioSource.PlayOneShot(clip);
			}
		}
	}

}
