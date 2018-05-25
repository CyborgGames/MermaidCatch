using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBoundary : MonoBehaviour {

	[SerializeField]
	int direction = 1;

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ball") {
			Debug.Log("Collided with ball.");
			float adjust = direction * 10f;
			other.rigidbody.AddForce(new Vector2(adjust, 0));
		}
	}
}
