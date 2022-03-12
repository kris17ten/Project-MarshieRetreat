using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effects : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        //make the power ups rotate just because ^_^
        if (gameObject.name == "GlowCandy(Clone)" || gameObject.name == "GumBall(Clone)" || gameObject.name == "Coin(Clone)")
        {
            gameObject.transform.Rotate(0, 0, 2);
        }
        else
        {
            gameObject.transform.Rotate(0, 2, 0);
        }
    }
}
