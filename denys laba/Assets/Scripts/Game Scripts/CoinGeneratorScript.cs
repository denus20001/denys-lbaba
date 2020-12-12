using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneratorScript : MonoBehaviour {

	public ObjectPooler coinPooler;

	public float coinDistance;

	public void spawnCoins (Vector3 startPosition) {
		GameObject coin1 = coinPooler.GetPooledObject ();
		coin1.transform.position = startPosition;
		coin1.SetActive (true);

		GameObject coin2 = coinPooler.GetPooledObject ();
		coin2.transform.position = new Vector3 (startPosition.x - coinDistance, startPosition.y, startPosition.z);
		coin2.SetActive (true);

		GameObject coin3 = coinPooler.GetPooledObject ();
		coin3.transform.position = new Vector3 (startPosition.x + coinDistance, startPosition.y, startPosition.z);
		coin3.SetActive (true);

		GameObject coin4 = coinPooler.GetPooledObject ();
		coin4.transform.position = new Vector3 (startPosition.x - 2.6f, startPosition.y, startPosition.z);
		coin4.SetActive (true);

		GameObject coin5 = coinPooler.GetPooledObject ();
		coin5.transform.position = new Vector3 (startPosition.x - 3.9f, startPosition.y, startPosition.z);
		coin5.SetActive (true);
	}
}
