using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
	public Image[] hearts;

	int index = 0;
	
	public void Reset() {
		foreach(Image heart in hearts) {
			heart.enabled = true;
		}
		
		index = 0;
	}

	public void Decrease() {
		if (index < hearts.Length) {
			index++;
			hearts[hearts.Length - index].enabled = false;
		}
	}
	
}
