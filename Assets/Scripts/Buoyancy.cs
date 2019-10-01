using UnityEngine;

public class Buoyancy : MonoBehaviour
{

    // The rigidbody of the buoyant object
    Rigidbody2D rigidbody;

    // The force of buoyancy
    float force = 1.5f;

    void Start()
    {
	rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

	if (transform.position.y < 0) {
	    Float();
	} else if (transform.position.y > 2) {
	    rigidbody.AddForce(transform.up * -force);
	}
    }

    // If below the water level, float
    void Float() {
	rigidbody.AddForce(transform.up * force);
    }

}
