using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateForeGround : MonoBehaviour {

	public GameObject foregroundGenerator;
	public Transform generatePoint;

	private int groundSelect;
	public GameObject[] groundArray;

	private float minHeight;
	private float maxHeight;
	public Transform heightPoint;

	public float maxHeightChange;
	private float heightChange;

	public float distance;
	private float width;


	void Start () {

		width = foregroundGenerator.GetComponent<BoxCollider2D> ().size.x;

		minHeight = transform.position.y;
		maxHeight = heightPoint.position.y;
	}
	

	void Update () {
		if(transform.position.x < generatePoint.position.x) {

			transform.position = new Vector3 (transform.position.x  + distance, heightChange, transform.position.z);

			groundSelect = Random.Range (0, groundArray.Length);

			Instantiate (groundArray[groundSelect], transform.position, transform.rotation);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if(heightChange > maxHeight) {
				heightChange = maxHeight;

			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}
		}
	}
}
