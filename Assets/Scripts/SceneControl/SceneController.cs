using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace MermaidCatch {
	
	public class SceneController : Singleton<SceneController>
	{

		public SceneConfig config;

		public SceneFader Fader;

		public void SwitchScene(string sceneName) {
			if (SceneManager.GetActiveScene().name != sceneName) {
				StartCoroutine(FadeAndSwitchScenes(sceneName));
			}
		}
		
		IEnumerator Start() {
			Fader = SceneFader.Instance;

			yield return LoadUI();

			yield return LoadMainMenu();
		}

		IEnumerator LoadUI() {
			yield return SceneManager.LoadSceneAsync(config.Score, LoadSceneMode.Additive);
		}

		IEnumerator LoadMainMenu() {
			yield return StartCoroutine(Fader.FadeOut());

			yield return StartCoroutine(LoadSceneAndSetActive(config.Title));
										
			yield return StartCoroutine(Fader.FadeIn());
		}
				
		IEnumerator LoadSceneAndSetActive(string sceneName) {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            // TODO: Show a loading screen

            yield return asyncLoad;

            Scene newlyLoadedScene = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene (newlyLoadedScene);

		}
		
		IEnumerator FadeAndSwitchScenes(string sceneName) {
			
            // Fade to black
            yield return StartCoroutine(Fader.FadeOut());

            yield return SwitchToScene(sceneName);

            // Fade from black
            yield return StartCoroutine(Fader.FadeIn());

		}
		
		IEnumerator SwitchToScene(string sceneName) {
			yield return SwitchToScene(SceneManager.GetActiveScene().name, sceneName);
		}
		
        // Unload the old scene and load the new scene
        IEnumerator SwitchToScene(string oldScene, string newScene) {
            if (!IsActiveScene(newScene) && Application.CanStreamedLevelBeLoaded(newScene)) {
				yield return SceneManager.UnloadSceneAsync(oldScene);
				yield return StartCoroutine(LoadSceneAndSetActive(newScene));
            } else {
                Debug.Log("Can't switch scenes.");
            }
        }
	
		bool IsActiveScene(string sceneName) {
			return SceneManager.GetActiveScene().name == sceneName;
		}
		
		
	}

}
