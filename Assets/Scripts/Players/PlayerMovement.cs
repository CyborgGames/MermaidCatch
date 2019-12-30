using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {

	// Moves the player based on keyboard or touch input
	public class PlayerMovement : MonoBehaviour
	{

		public Animator animator;
		
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
				// TODO: Touchscreen movement
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

			if (movementSpeedY != 0) {
				// TODO: Update animator				
				transform.Translate(0, movementSpeedY, 0);
			}

			UpdateAnimator(movementSpeedY);

		}

		void UpdateAnimator(float speed) {
			if (animator != null) {
				Debug.Log("Setting animator speed to " + Mathf.Abs(speed));
				animator.SetFloat("Speed", speed);
			}
		}

		
	}
}
	
