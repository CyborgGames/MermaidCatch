using UnityEngine;

namespace MermaidCatch {
	
	public class Buoyancy : MonoBehaviour
	{
				
		// The force of buoyancy
		float force = 1.5f;
		
		const float WATERLINE_Y = 2f;		

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
			GetComponent<Rigidbody>().AddForce(transform.up * force);
		}

		void Sink() {
			GetComponent<Rigidbody>().AddForce(transform.up * -force);
		}
		
	}
}
	
