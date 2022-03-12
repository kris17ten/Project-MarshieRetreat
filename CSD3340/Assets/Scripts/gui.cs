using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //update all the text components on gui
        if (gameObject.name == "TimeText") {
            GetComponent<Text>().text = "Time: " + Mathf.Round(gameManagerScript.timeTotal * 100f) / 100f;
        }
        if (gameObject.name == "ScoreText") {
            GetComponent<Text>().text = "Score: " + gameManagerScript.score;
        }
        if (gameObject.name == "CoinText") {
            GetComponent<Text>().text = "" + gameManagerScript.coinTotal;
        }
        if (gameObject.name == "CheckPtText")
        {
            GetComponent<Text>().text = "" + gameManagerScript.flagTotal;
        }
    }
}
