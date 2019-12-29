using UnityEngine;

namespace MermaidCatch {
	
	public class Buoyancy : MonoBehaviour
	{
		
		// The rigidbody of the buoyant object
		Rigidbody2D rigidbody;
		
		// The force of buoyancy
		float force = 1.5f;
		
		const float WATERLINE_Y = 2f;
		
		void Start()
		{
			rigidbody = GetComponent<Rigidbody2D>();
		}

		void FixedUpdate()
		{
			
			if (transform.position.y < 0) {
				Float();
			} else if (transform.position.y > WATERLINE_Y) {
				Sink();
			}
		}
		
		// If below the water level, float
		void Float() {
			rigidbody.AddForce(transform.up * force);
		}

		void Sink() {
			rigidbody.AddForce(transform.up * -force);
		}
		
	}
}
	
