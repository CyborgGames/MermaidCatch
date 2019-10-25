using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace MermaidCatch {
	
	public class SceneController : Singleton<SceneController>
	{

		public SceneConfig config;

		public SceneFader Fader;

		public void ToMainMenu() {
			StartCoroutine(LoadMainMenu());
		}
		
		IEnumerator LoadMainMenu() {
			Debug.Log("Fading in");
			
			yield return StartCoroutine(Fader.FadeOut());

			ScoreUI.Instance.Hide();

			Debug.Log("Loading Title");
			yield return StartCoroutine(LoadSceneAndSetActive(config.Title));

			Debug.Log("Fading out");
			
			yield return StartCoroutine(Fader.FadeIn());
		
		}
		
		// Use the Scene Controller pipeline to switch to the given scene
		public void SwitchScene(string sceneName) {
			if (!IsActiveScene(sceneName)) {
				StartCoroutine(FadeAndSwitchScenes(sceneName));
			} else {
				Debug.LogError(sceneName + " is already active!");
			}
		}
		
		IEnumerator Start() {
			Fader = SceneFader.Instance;

			yield return LoadUI();

			yield return LoadMainMenu();
		}

		// Load all UI scenes
		IEnumerator LoadUI() {
			yield return SceneManager.LoadSceneAsync(config.Score, LoadSceneMode.Additive);
		}

				
		IEnumerator LoadSceneAndSetActive(string sceneName) {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            Scene newlyLoadedScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene (newlyLoadedScene);

		}
		
		IEnumerator FadeAndSwitchScenes(string sceneName) {

			ScoreUI.Instance.Hide();
			
            // Fade to black
            yield return StartCoroutine(Fader.FadeOut());

            yield return SwitchToScene(sceneName);

			ScoreUI.Instance.Show();
			
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
                Debug.LogError("Can't switch scenes.");
            }
        }
	
		bool IsActiveScene(string sceneName) {
			return SceneManager.GetActiveScene().name == sceneName;
		}
		
		
	}

}
