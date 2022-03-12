using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyerScript : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //move with cam
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4 * gameManagerScript.zVelocityFactor);
        //Debug.Log(transform.position.z);
    }

    //on collision, just destroy the object
    void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
    }
}
