using UnityEngine;

namespace MermaidCatch {

	// Behavior for the enemy player
	public class Enemy : Paddle {

		Ball[] balls;
		
		void Update () {
			ChaseNearestBall();
			UpdateDirection();
		}
		
		// If there's a ball in range, chase it
		void ChaseNearestBall() {
			Ball ball = GetNearestBall();
			if (ball == null) {
				return;
			} else if (IsBallMovingTowardsMe(ball)) {
				ChaseBall(ball);
			}
		}
		
		// Chase the given ball
		void ChaseBall(Ball ball) {
			
			Transform ballTransform = ball.gameObject.transform;
			
			// Check y direction of ball
			if (IsHigherThan(ballTransform)) {
				
				// Move ball down if lower than paddle
				transform.Translate(Vector3.down * _speed * Time.deltaTime);
				
			} else if (IsLowerThan(ballTransform)) {
				
				// Move ball up if higher than paddle
				transform.Translate(Vector3.up * _speed * Time.deltaTime);
			}
		}
		
		// Is the ball moving towards this character?
		// TODO: Arbitrary based on velocity
		bool IsBallMovingTowardsMe(Ball ball) {
			Rigidbody2D ballRigidBody = ball.GetComponent<Rigidbody2D>();
			return ballRigidBody.velocity.x < 0;
		}
		
		Ball GetNearestBall() {
			balls = FindObjectsOfType<Ball>();
			
			// Stop if there are no balls
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

}
