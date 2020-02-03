using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {
	
    public class SpawnPoint : MonoBehaviour
    {
	float MinDelay = 2.0f;
	float MaxDelay = 0.5f;
	
	protected bool isSpawning = false;
	
	protected float Delay {
	    get {
		return Random.Range(MinDelay, MaxDelay);
	    }
	}
	
	protected Vector2 GetSpawnPosition() {
	    return transform.position;
	}
	
	protected Quaternion GetSpawnRotation() {
	    return transform.rotation;
	}
    }
    
}
