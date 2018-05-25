using UnityEngine;

public class Buoyancy : MonoBehaviour
{

	Rigidbody2D rigidbody;
	float force = 1.5f;

	/// <summary>
	/// Provides initialization.
	/// </summary>
	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	/// <summary>
	/// Calculates physics.
	/// </summary>
	private void FixedUpdate()
	{
		// If below the water level, float
		if (transform.position.y < 0) {
			rigidbody.AddForce(transform.up * force);
		} else if (transform.position.y > 2) {
			rigidbody.AddForce(transform.up * -force);
		}
		
	}

}