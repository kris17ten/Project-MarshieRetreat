using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour {
    //initialize all score variables
    public int distScore = 0;
    public int coinsScore = 0;
    public float timeTtl = 0;
    public int timeScore = 0;
    public int powerUpScore = 0;
    public int livesScore = 0;
    public int finalScore = 0;

    public int animate = 0;
    
    //initialize variables for high score
    public int hs1;
    public int hs2;
    public int hs3;
    public int hs4;
    public int hs5;
    
    // Use this for initialization
    void Start () {
        //get all the scores
        distScore = gameManagerScript.score;
        coinsScore = gameManagerScript.coinTotal;
        timeTtl = gameManagerScript.timeTotal;
        if (gameManagerScript.levelComp == "fail") {
            timeScore = 0; //if failed, no time bonus
        } else {
            timeScore = (int)gameManagerScript.zLimit - (int)timeTtl;
        }
        powerUpScore = gameManagerScript.powerUpTotal * 10;
        livesScore = gameManagerScript.lives * 30;
        finalScore = distScore + coinsScore + timeScore + powerUpScore + livesScore;

        //get all the high scores from PlayerPrefs
        hs1 = PlayerPrefs.GetInt("highScores1", 0);
        hs2 = PlayerPrefs.GetInt("highScores2", 0);
        hs3 = PlayerPrefs.GetInt("highScores3", 0);
        hs4 = PlayerPrefs.GetInt("highScores4", 0);
        hs5 = PlayerPrefs.GetInt("highScores5", 0);
        //PlayerPrefs.DeleteAll();
        if (gameObject.name == "ScoreKeeper") {
            StoreHighScore();
        } 
    }
	
	// Update is called once per frame
	void Update () {
        //update all the text components on scene
        if (gameObject.name == "LevelComplete") {
            if (gameManagerScript.levelComp == "fail") {
                GetComponent<Text>().text = "Level Failed!";
            } else {
                GetComponent<Text>().text = "Level Complete!";
            }
        }
        if (gameObject.name == "TimeTaken") {
            GetComponent<Text>().text = "Time Taken: " + Mathf.Round(timeTtl * 100f) / 100f;
        }
        if (gameObject.name == "TimeBonus")
        {
            GetComponent<Text>().text = "Time Bonus: " + timeScore;
        }
        if (gameObject.name == "Score")
        {
            GetComponent<Text>().text = "Score: " + distScore;
        }
        if (gameObject.name == "CoinCollect")
        {
            GetComponent<Text>().text = "Coins Collected: " + coinsScore;
        }
        if (gameObject.name == "LivesBonus")
        {
            GetComponent<Text>().text = "Lives Bonus: " + livesScore;
        }
        if (gameObject.name == "PowerUpsCollect")
        {
            GetComponent<Text>().text = "PowerUp Bonus: " + powerUpScore;
        }
        if (gameObject.name == "TotalScore")
        {
            GetComponent<Text>().text = "Final Score: " + finalScore;
        }

    }

    //function to store high score
    void StoreHighScore()
    {
        if(finalScore > hs1)
        {
            PlayerPrefs.SetInt("highScores5", hs4);
            PlayerPrefs.SetInt("highScores4", hs3);
            PlayerPrefs.SetInt("highScores3", hs2);
            PlayerPrefs.SetInt("highScores2", hs1);
            PlayerPrefs.SetInt("highScores1", finalScore);
            //Debug.Log("#1");
        }
        else if (finalScore > hs2)
        {
            PlayerPrefs.SetInt("highScores5", hs4);
            PlayerPrefs.SetInt("highScores4", hs3);
            PlayerPrefs.SetInt("highScores3", hs2);
            PlayerPrefs.SetInt("highScores2", finalScore);
            //Debug.Log("#2");
        }
        else if (finalScore > hs3)
        {
            PlayerPrefs.SetInt("highScores5", hs4);
            PlayerPrefs.SetInt("highScores4", hs3);
            PlayerPrefs.SetInt("highScores3", finalScore);
            //Debug.Log("#3");
        }
        else if (finalScore > hs4)
        {
            PlayerPrefs.SetInt("highScores5", hs4);
            PlayerPrefs.SetInt("highScores4", finalScore);
            //Debug.Log("#4");
        }
        else if (finalScore > hs5)
        {
            PlayerPrefs.SetInt("highScores5", finalScore);
            //Debug.Log("#5");
        }
        else
        {
            //Debug.Log("Not good enough! :(");
        }
    }

    public static void RestartGame()
    {
        gameManagerScript.zBlockPosition = 0;
        gameManagerScript.score = 0;
        gameManagerScript.previousLifeScore = 0;
        gameManagerScript.timeTotal = 0;
        gameManagerScript.powerUpTotal = 0;
        gameManagerScript.lives = 3;
        gameManagerScript.flagTotal = 0;
        gameManagerScript.coinTotal = 0;
        gameManagerScript.zVelocityFactor = 0;
        gameManagerScript.startTime = false;
        //creatorScript.zObjCreate = 0;
    }
}
