using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {

	public class Fish : MonoBehaviour
	{

		public float Speed = 0.2f;
		
		Vector3 startPosition;
		
		void OnEnable() {
			UIEvents.OnStartGame += Reset;
		}

		void OnDisable() {
			UIEvents.OnStartGame -= Reset;
		}
		
		void Awake() {
			startPosition = transform.position;
			Move();
		}

		void Move() {
			GetComponent<Rigidbody2D>().velocity = new Vector3(Speed, 0, 0);
		}

		 void Reset() {
			 transform.position = startPosition;
			 Move();
		 }
	}

}
