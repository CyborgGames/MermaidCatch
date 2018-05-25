using UnityEngine;

public class Player : MonoBehaviour {

	int direction;
	float previousPositionY;

	[SerializeField]
	public float _speed = 0.2f;
	float _bottomBound = -4.5f;
	float _topBound = 4.5f;

	void Start () {
		UpdatePreviousPosition();
	}

	void FixedUpdate() {
		Move();
	}

	void LateUpdate() {
		UpdatePreviousPosition();
	}

	void UpdatePreviousPosition() {
		previousPositionY = transform.position.y;
	}

	protected void Move() {
		float vertical = 0;
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
			KeyboardMovement();
		#elif UNITY_IOS || UNITY_ANDROID 
			TouchMovement();
		#endif
		
		UpdateDirection();
		SetBoundaries();
	}

	protected virtual void KeyboardMovement() {
		// Override me
	}

	protected virtual void TouchMovement() {
		// Override me
	}

	protected void UpdateDirection() {
		if (previousPositionY > transform.position.y) {
		    direction = -1;
		} else if (previousPositionY < transform.position.y) {
		    direction = 1;
		} else {
		    direction = 0;
		}
	}

	protected void SetBoundaries() {
		// Clamp the position so the player doesn't go over the edge of the screen
		float clampedY = Mathf.Clamp(transform.position.y, _bottomBound, _topBound);
		transform.position = new Vector3(transform.position.x, clampedY, 0);	
	}

	protected float GetScreenMidpointX() {
		return Screen.width/2.0f;
	}


}
