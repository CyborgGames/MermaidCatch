using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {

	[RequireComponent(typeof(CanvasGroup))]
	public class SceneFader : Singleton<SceneFader>
	{
		private CanvasGroup faderCanvasGroup;
		private float fadeDuration = 1f;
		private bool isFading;

		public IEnumerator FadeOut() {
			yield return Fade(1f);
		}

		public IEnumerator FadeIn() {
			yield return Fade(0f);
		}

		void Awake()  {
			faderCanvasGroup = GetComponent<CanvasGroup>();
			faderCanvasGroup.alpha = 1f;
		}

		IEnumerator Fade(float finalAlpha) {
		
			isFading = true;
			faderCanvasGroup.blocksRaycasts = true;
			
			float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha) / fadeDuration;

			while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha)) {
				faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
				yield return null;
			}

			isFading = false;
			faderCanvasGroup.blocksRaycasts = false;
		}
		
	}
	

}
