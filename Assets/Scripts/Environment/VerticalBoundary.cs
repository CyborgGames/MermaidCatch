using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBoundary : MonoBehaviour {

    [SerializeField]
    int direction = 1;

    const float FORCE = 10f;
    
    void OnCollisionExit2D(Collision2D other)
    {
	if (other.gameObject.tag == "Ball") {

	    // Debug.Log("Collided with ball.");

	    other.rigidbody.AddForce(new Vector2(direction * FORCE, 0));
	}
    }

}
