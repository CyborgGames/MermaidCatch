using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {

	public class Spear : MonoBehaviour
	{
		
		void OnCollisionEnter2D(Collision2D other) {
			Debug.Log("Collision");
			if (other.gameObject.tag == "Ball") {
				Debug.Log("Spear collided with ball.");
				AudioEvents.PlaySound("plop");
			}
		}
	}
}
