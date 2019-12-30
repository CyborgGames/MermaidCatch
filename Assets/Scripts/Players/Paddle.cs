using UnityEngine;

namespace MermaidCatch {
	
	public class Paddle : Player {
		
		int direction;
		
		void FixedUpdate() {
			UpdateDirection();
		}
		
		void OnCollisionExit2D(Collision2D other)
		{
			if (other.gameObject.tag == "Ball") {
				AudioController.PlayPlop();
				
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
		
	}

}
