using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    float forceValue = 3.5f;
    
    const float forceValueX = 50;
    const float forceValueY = -10;

    // Components of the ball
    public Rigidbody2D rigidBody;

    // Push the ball
    public void Push() {
	if (rigidBody == null) {
	    Debug.LogError("Rigidbody must be initialized.");
	    return;
	}
	rigidBody.AddForce(new Vector2(forceValue * forceValueX * GetDirection(),
				       forceValueY * forceValue));
    }
    
    // Initialize components
    void Awake() {
	rigidBody = GetComponent<Rigidbody2D>();
    }

    // Handle collisions
    void OnCollisionEnter2D(Collision2D other)
    {
	if (other.gameObject.tag == "Ball") {
	    HandleCollideWithBall(other.gameObject);
	}
    }

    // Handle a collision with another ball. Both balls "pop".
    void HandleCollideWithBall(GameObject otherBall) {
	Debug.Log("Collided with another ball");

	// Destroy the other ball
	Destroy(otherBall);

	// Decrement the number of ball in BallSpawner
	BallSpawner.NumberOfBalls--;
    }

    // Randomly generate -1 or 1
    int GetDirection() {
	return Random.Range(0, 2) == 0 ? -1 : 1;
    }

}
