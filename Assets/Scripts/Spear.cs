﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MermaidCatch {

	public class Spear : MonoBehaviour
	{
		
		void OnCollisionEnter2D(Collision2D other) {
			if (other.gameObject.tag == "Ball") {
				AudioController.PlayPlop();

			}
		}
	}
}
