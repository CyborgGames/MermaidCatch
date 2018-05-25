using UnityEngine;

public class Player1 : Player {

	protected override void KeyboardMovement() {
		//get player input and set speed
		float movementSpeedY = _speed * Input.GetAxis("Vertical") * Time.deltaTime;
		transform.Translate(0, movementSpeedY, 0);
	}

	protected override void TouchMovement() {
		if (Input.touchCount > 0) {
			Touch theTouch = Input.touches[0];
			if (theTouch.phase == TouchPhase.Moved && theTouch.position.x > GetScreenMidpointX()) {
				transform.Translate(0, theTouch.deltaPosition.y * 0.025f, 0);
            }
		}
	}
}
