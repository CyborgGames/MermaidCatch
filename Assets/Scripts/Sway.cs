using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {
	
	public class Sway : MonoBehaviour
	{

		public float Range = 0.2f;
		public float Speed = 5.0f;
	   
		void Start()
		{
			Speed = Random.Range(Speed - 2, Speed);
			
			// Initial rotation
			transform.Rotate(Vector3.back * Range * Mathf.Sin(Random.Range(0f, 2f) * Speed));
		}
		
		// Rotate back and forth;
		void FixedUpdate() {
			if (GameManager.IsMenu) {
				// Do nothing
			} else {
				Animate();
			}
		}

		void Animate() {
			transform.Rotate(Vector3.forward * Range * Mathf.Sin(Time.timeSinceLevelLoad * Speed));
		}
		
	}
}
	
