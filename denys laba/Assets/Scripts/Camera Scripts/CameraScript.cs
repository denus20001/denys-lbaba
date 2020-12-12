using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public PlayerMoveScript player;

	private Vector3 lastPlayerPosition;
	private float distance;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerMoveScript> ();
		lastPlayerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distance = player.transform.position.x - lastPlayerPosition.x;

		transform.position = new Vector3 (transform.position.x + distance, transform.position.y, transform.position.z);

		lastPlayerPosition = player.transform.position;
	}
}









