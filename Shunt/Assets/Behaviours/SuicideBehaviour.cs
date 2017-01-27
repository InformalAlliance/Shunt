using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBehaviour : MonoBehaviour {

    public float delay = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, delay);
	}
}
