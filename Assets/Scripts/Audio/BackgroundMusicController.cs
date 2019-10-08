using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {
	
	public class BackgroundMusicController : SoundController
	{

		void OnEnable() {
			AudioEvents.OnPlayMusic += PlayMusic;
		}
		
		void OnDisable() {
			AudioEvents.OnPlayMusic -= PlayMusic;
		}
		
		public void PlayMusic(string clipName) {
			PlayClip(GetClipByName(clipName));
		}
    }

}
