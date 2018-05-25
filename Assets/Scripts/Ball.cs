using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField]
	float forceValue = 3.5f;

	//ball's components
	private Rigidbody2D rigidBody;


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ball") {
			Debug.Log("Collided with another ball");
			Destroy(other.gameObject);
			BallSpawner.NumberOfBalls--;
		}
	}

	public void Push() {
		int direction = Random.Range(0, 10);
		if (direction < 5) {
			direction = -1;
		} else {
			direction = 1;
		}
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		rigidBody.AddForce(new Vector2(forceValue * 50 * direction, -10 * forceValue));
	}
}
