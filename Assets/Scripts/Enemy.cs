using UnityEngine;

public class Enemy : Paddle {

	Rigidbody2D ballRigidBody;
	Ball[] balls;

	void Update () {
		AIMove();
		UpdateDirection();
	}

	void AIMove() {
		ChaseBall();
		UpdateDirection();

	}

	void ChaseBall() {

		Ball ball = GetNearestBall();
		if (ball == null) {
			// no balls to chase
			return;
		}

		//setting the ball's rigidbody to a variable
		ballRigidBody = ball.GetComponent<Rigidbody2D>();

		// Check x direction of the ball
		if (ballRigidBody.velocity.x < 0) {
			Transform ballTransform = ball.gameObject.transform;
			
			// Check y direction of ball
			if (IsHigherThan(ballTransform)) {
				//move ball down if lower than paddle
				transform.Translate(Vector3.down * _speed * Time.deltaTime);
			} else if (IsLowerThan(ballTransform)) {
				//move ball up if higher than paddle
				transform.Translate(Vector3.up * _speed * Time.deltaTime);
			}
		}
	}

	Ball GetNearestBall() {
		balls = FindObjectsOfType<Ball>();

		if (balls.Length == 0) {
			return null;
		}

		float distance = 10000f;
		float thisDistance;
		Ball targetBall = null;
		foreach(Ball ball in balls) {
			thisDistance = Vector2.Distance(transform.position, ball.transform.position);
			if (thisDistance < distance) {
				targetBall = ball;
				distance = thisDistance;
			}
		}

		return targetBall;
	}

	bool IsHigherThan(Transform other) {
		return transform.position.y - other.position.y > 0.5f;
	}

	bool IsLowerThan(Transform other) {
		return other.position.y - transform.position.y > 0.5f;
	}
}
