using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //move cam with player
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4 * gameManagerScript.zVelocityFactor);
    }
}
