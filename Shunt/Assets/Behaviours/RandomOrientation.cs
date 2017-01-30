// ARW 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOrientation : MonoBehaviour {
	// on initialise, sets object to a random rotation within range set
	public Vector3 range;
	public bool localRotation;

	void Start () {
		// on script initialise, pick random rotation and set it
		if (localRotation) {
			transform.localEulerAngles = new Vector3 (Random.Range (-range.x, range.x),
				Random.Range (-range.y, range.y), Random.Range (-range.z, range.z));
		} else {
			transform.eulerAngles = new Vector3 (Random.Range (-range.x, range.x),
				Random.Range (-range.y, range.y), Random.Range (-range.z, range.z));
		}
	}
}
