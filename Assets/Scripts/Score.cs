using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {
	
    public class Score 
    {
	
	int red = 0;
	int blue = 0;
	
	public Score() {
	    Reset();
	}
	
	public int GetScore(PlayerEnum player) {
	    if (player == PlayerEnum.Red) {
		return red;
	    } else {
		return blue;
	    }
	}
		
	public void Increment(PlayerEnum player) {
	    if (player == PlayerEnum.Red) {
		red++;
	    } else {
		blue++;
	    }
	}
	
	public void Reset() {
	    red = 0;
	    blue = 0;
	}		
    }
}
