using UnityEngine;

public class Player : MonoBehaviour {

    public string InputAxis = "Vertical";
    
    int direction;
    float previousPositionY;
    
    [SerializeField]
    public float _speed = 0.2f;

    const float BOTTOM_BOUND = -4.5f;
    float TOP_BOUND  = 4.5f;
    
    void Start () {
	UpdatePreviousPosition();
    }
    
    void FixedUpdate() {
	Move();
    }
    
    void LateUpdate() {
	UpdatePreviousPosition();
    }
    
    void UpdatePreviousPosition() {
	previousPositionY = transform.position.y;
    }
    
    protected void Move() {
	float vertical = 0;
#if UNITY_STANDALONE || UNITY_WEBPLAYER
	KeyboardMovement();
#elif UNITY_IOS || UNITY_ANDROID 
	TouchMovement();
#endif
	
	UpdateDirection();
	SetBoundaries();
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

    // Clamp the position so the player doesn't go over the edge of the screen
    protected void SetBoundaries() {
	float clampedY = Mathf.Clamp(transform.position.y, BOTTOM_BOUND, TOP_BOUND);
	transform.position = new Vector3(transform.position.x, clampedY, 0);	
    }

    protected float GetScreenMidpointX() {
	return Screen.width/2.0f;
    }

    // Get player input and set speed
    protected void KeyboardMovement() {
	float movementSpeedY = _speed * Input.GetAxis(InputAxis) * Time.deltaTime;
	transform.Translate(0, movementSpeedY, 0);
    }
    
    protected void TouchMovement() {
	if (Input.touchCount > 0) {
	    Touch theTouch = Input.touches[0];
	    if (theTouch.phase == TouchPhase.Moved && theTouch.position.x > GetScreenMidpointX()) {
		transform.Translate(0, theTouch.deltaPosition.y * 0.025f, 0);
            }
	}
    }

}
