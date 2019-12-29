using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {
	
	public class PlayerMovement : MonoBehaviour
	{
		
		public string InputAxis = "Vertical";
		
		[SerializeField]
		public float _speed = 4f;
		
		// Update is called once per frame
		void FixedUpdate()
		{
			Move();
		}
		
		void Move() {
			if (IsMobile()) {
				TouchMovement();
			} else {
				KeyboardMovement();
			}
		}
		
		bool IsMobile() {
			return Application.isMobilePlatform;
		}
		
		// Get player input and set speed
		protected void KeyboardMovement() {
			float movementSpeedY = _speed * Input.GetAxis(InputAxis) * Time.deltaTime;
			transform.Translate(0, movementSpeedY, 0);
		}
		
		// Move via touch input
		protected void TouchMovement() {
			if (Input.touchCount > 0) {
				Touch theTouch = Input.touches[0];
				if (theTouch.phase == TouchPhase.Moved && theTouch.position.x > GetScreenMidpointX()) {
					transform.Translate(0, theTouch.deltaPosition.y * 0.025f, 0);
				}
			}
		}
		
		protected float GetScreenMidpointX() {
			return Screen.width/2.0f;
		}
		
	}
}
	
