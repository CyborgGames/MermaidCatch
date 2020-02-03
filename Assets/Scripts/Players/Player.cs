using UnityEngine;

namespace MermaidCatch {
	
    public class Player : MonoBehaviour {
	
	protected float previousPositionY;
	
	// The maximum and minimum position for the player
	const float BOTTOM_BOUND = -4.5f;
	const float TOP_BOUND  = 4.5f;
	
	void Start () {
	    UpdatePreviousPosition();
	}
	
	void FixedUpdate() {
	    SetBoundaries();
	}
	
	void LateUpdate() {
	    UpdatePreviousPosition();
	}
	
	void UpdatePreviousPosition() {
	    previousPositionY = transform.position.y;
	}		
	
	// Clamp the position so the player doesn't go over the edge of the screen
	protected void SetBoundaries() {
	    float clampedY = Mathf.Clamp(transform.position.y, BOTTOM_BOUND, TOP_BOUND);
	    transform.position = new Vector3(transform.position.x, clampedY, 0);	
	}
	
    }
	
}
