using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour {


	void Start() {
		
	}

	void OnTriggerEnter2D(Collider2D target){
		if(target.tag == "Grounded") {

			target.gameObject.SetActive (false);
		}
	}
}
