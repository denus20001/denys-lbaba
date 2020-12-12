using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrounds : MonoBehaviour {

	public GameObject groundGenerator;
	public Transform generatePoint;
	public float distance;
	//private float width;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private int groundSelector;
	private float[] groundWidth;
	public ObjectPooler[] theObjectPools;

	public Transform maxHeightPoint;
	private float minHeight;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private CoinGeneratorScript coinGenerator;
	public float randomCoins;

	private CrateGeneratorScript cratesGenerator;
	public float randomCrates;


	void Start () {
		
		groundWidth = new float[theObjectPools.Length];	

		for(int i = 0; i < theObjectPools.Length; i++) {
			groundWidth [i] = theObjectPools [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		coinGenerator = FindObjectOfType<CoinGeneratorScript> ();
		cratesGenerator = FindObjectOfType<CrateGeneratorScript> ();
	}


	void Update () {
		if(transform.position.x < generatePoint.position.x) {

			distance = Random.Range (distanceBetweenMin, distanceBetweenMax);

			groundSelector = Random.Range (0, theObjectPools.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}

			transform.position = new Vector3 (transform.position.x + (groundWidth[groundSelector] / 2) + distance, heightChange, transform.position.z);

			GameObject newPlatform = theObjectPools[groundSelector].GetPooledObject ();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);  

			if(Random.Range(0f, 100f) < randomCoins) {
				coinGenerator.spawnCoins (new Vector3 (transform.position.x, transform.position.y + 3f, transform.position.z));
			}

			if(Random.Range(0f, 100f) < randomCrates) {
				cratesGenerator.spawnCrates (new Vector3 (transform.position.x, transform.position.y + 1.3f, transform.position.z));
			}

			transform.position = new Vector3 (transform.position.x + (groundWidth[groundSelector] / 2) + distance, transform.position.y, transform.position.z);

		}
	}
}










































