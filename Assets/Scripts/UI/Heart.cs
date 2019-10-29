using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{

	Image img;
	
	bool isAnimating = false;

	float duration = 1.5f;
	
	public void Gain() {
		img.color = Color.white;
		isAnimating = false;
	}

	public void Lose() {
		isAnimating = true;
	}

	void Awake() {
		img = GetComponent<Image>();
	}
	
	void Update() {
		if (isAnimating) {
			img.color = Color.Lerp(img.color, Color.clear, Time.deltaTime * duration);
			if (img.color == Color.clear) {
				isAnimating = false;
			}	
		}	   		
	}

}
