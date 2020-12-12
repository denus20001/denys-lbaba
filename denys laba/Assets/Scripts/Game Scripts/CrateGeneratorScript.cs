using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateGeneratorScript : MonoBehaviour {

	public ObjectPooler cratePooler;

	public float crateDistance;

	public void spawnCrates(Vector3 startPosition) {
		
		GameObject crate = cratePooler.GetPooledObject ();
		crate.transform.position = new Vector3 (startPosition.x - 1f, startPosition.y, startPosition.z);
		crate.SetActive (true);

	}
}
