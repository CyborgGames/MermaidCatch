using System;
using UnityEngine;

namespace MermaidCatch {

	[RequireComponent(typeof(AudioSource))]
	public abstract class SoundController : MonoBehaviour
	{
		public AudioClip[] clips;

		protected AudioSource audioSource;

		void Start() {
			audioSource = GetComponent<AudioSource>();
		}

		protected void PlayClip(AudioClip clip) {
			if (clip != null) {
				audioSource.clip = clip;
				Play();
			}
		}

        // Play the audio source
        void Play() {
			audioSource.Play();
        }

		protected AudioClip GetClipByName(string clipName) {
           return Array.Find(clips, element => element.name.ToLower() == clipName.ToLower());	
		}

		protected bool IsPlaying(string clipName) {
            return audioSource.clip && audioSource.clip.name.ToLower() == clipName.ToLower();
		}
		
	}

}
