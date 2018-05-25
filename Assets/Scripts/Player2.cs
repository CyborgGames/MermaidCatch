using UnityEngine;

public class Player2 : Player {

	protected override void KeyboardMovement() {
		//get player input and set speed
		float movementSpeedY = _speed * Input.GetAxis("Vertical-WASD") * Time.deltaTime;
		transform.Translate(0, movementSpeedY, 0);
	}

	protected override void TouchMovement() {
		if (Input.touchCount > 0) {
			Touch theTouch = Input.touches[0];
			Debug.Log("Touch position x: " + theTouch.position.x);
			if (theTouch.phase == TouchPhase.Moved && theTouch.position.x < GetScreenMidpointX()) {
				transform.Translate(0, theTouch.deltaPosition.y * 0.025f, 0);
            }
		}
	}

}
