using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //update the text components to show all the high scores of previous games
		if(gameObject.name == "Score1")
        {
            string s1 = PlayerPrefs.GetInt("highScores1", 0) + "";
            GetComponent<Text>().text = s1;
        }
        if (gameObject.name == "Score2")
        {
            string s2 = PlayerPrefs.GetInt("highScores2", 0) + "";
            GetComponent<Text>().text = s2;
        }
        if (gameObject.name == "Score3")
        {
            string s3 = PlayerPrefs.GetInt("highScores3", 0) + "";
            GetComponent<Text>().text = s3;
        }
        if (gameObject.name == "Score4")
        {
            string s4 = PlayerPrefs.GetInt("highScores4", 0) + "";
            GetComponent<Text>().text = s4;
        }
        if (gameObject.name == "Score5")
        {
            string s5 = PlayerPrefs.GetInt("highScores5", 0) + "";
            GetComponent<Text>().text = s5;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
