using UnityEngine;

public class Paddle : MonoBehaviour {

	int direction;
	float previousPositionY;

	[SerializeField]
	protected float _speed = 0.2f;
	float _bottomBound = -4.5f;
	float _topBound = 4.5f;

	void Start() {
		previousPositionY = transform.position.y;
	}

	void LateUpdate() {
		previousPositionY = transform.position.y;
	}

	void FixedUpdate() {
		UpdateDirection();
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ball") {
			Debug.Log("Collided with ball.");
			float adjust = direction * 10f;
			other.rigidbody.AddForce(new Vector2(adjust, adjust));
		}
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

}
