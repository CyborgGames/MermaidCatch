using UnityEngine;

namespace MermaidCatch {

	[CreateAssetMenu(fileName = "SceneConfig", menuName = "Scene Config")]
	public class SceneConfig : ScriptableObject
	{
		public string FirstLevel = "Main";

		public string Title = "Title";

		public string Score = "Score";
	}
}
