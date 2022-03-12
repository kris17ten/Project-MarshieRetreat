using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManagerScript : MonoBehaviour
{
    public static float zVelocityFactor = 0; //velocity factor to control if character moves

    public static int coinTotal = 0; //total coins collected
    public static int flagTotal = 0; //total flags collected
    public static int powerUpTotal = 0; //total power ups collected
    public static float timeTotal = 0; //total time
    public static bool gameRunning = true; //is the game running?
    public static string levelComp = ""; //level status
    public float waitLoad = 0; //wait to load

    //all objects to instantiate
    public Transform character;

    public Transform noPoolObj;
    public Transform poolMidObj;
    public Transform poolLeftObj;
    public Transform poolRightObj;
    public Transform bridgeObj;

    //all objects to be instantiated
    public Transform sugarCubeObj;
    public Transform gumBallObj;
    public Transform glowCandyObj;
    public Transform coinObj;
    public Transform flagObj;
    public Transform chocoBarObj;
    public Transform rockObj;

    public static int objRandNumber; //object random number
    public static float zObjCreate; //move position of the creator to create objects
    public Text countdown;

    //lives sprite to enable change
    public Sprite lifeLost;
    public Sprite aliveSprite;

    public static float zBlockPosition = 0; //variable to create blocks 
    public static float zLimit = 20; //end of course - set to 20 initially to allow course to build 
    public static bool bridge = false; //currently on bridge?
    public static int blkRandNumber; //create blocks randomly
    public static bool startTime = false;

    public static int previousLifeScore = 0; //previous life score hold
    public static int score; //actual score - distance
    public static int lives = 3; //start with three lives

    // Use this for initialization
    void Start()
    {
        countdown = GameObject.Find("Countdown").GetComponent<Text>();
        //instantiate character
        Instantiate(character, new Vector3(0, 1.25f, 0), character.rotation);
        GameObject.Find("CharBody(Clone)").GetComponent<Animator>().enabled = false;
        //set z limit to end of course
        zLimit = GameObject.Find("Exit").transform.position.z;

        StartCoroutine(StartCountdown()); 
    }

    // Update is called once per frame
    void Update()
    {
        ChangeLifeBar(); //change lives on GUI
        //calculate the score in real time
        if (gameRunning)
        {
            score = (int)GameObject.Find("CharBody(Clone)").transform.position.z + previousLifeScore;
        }
        //create blocks
        if (zBlockPosition <= zLimit + 10)
        {
            CreateBlock();
            zBlockPosition += 4;
        }
        //if level failed, time stops; else run time
        if (levelComp == "fail")
        {
            timeTotal += 0;
        }
        else if(startTime)
        {
            timeTotal += Time.deltaTime;
        }
        //if level failed, run waitLoad
        if (levelComp == "fail")
        {
            waitLoad += Time.deltaTime;
        } //if waitLoad > 4, load level end scene
        if (waitLoad > 4)
        {
            SceneManager.LoadScene("LevelEnd");
        }
    }

    //initialize track
    void InitGameBlocks()
    {
        for (int i = 0; i <= 20; i += 4)
        {
            Instantiate(noPoolObj, new Vector3(0, 0, i), noPoolObj.rotation);
        }
    }

    //function to change sprites according to lives
    void ChangeLifeBar()
    {
        if (lives == 0)
        {
            GameObject.FindGameObjectsWithTag("life")[0].GetComponent<Image>().sprite = lifeLost;
            GameObject.FindGameObjectsWithTag("life")[1].GetComponent<Image>().sprite = lifeLost;
            GameObject.FindGameObjectsWithTag("life")[2].GetComponent<Image>().sprite = lifeLost;
        }
        else if (lives == 1)
        {
            GameObject.FindGameObjectsWithTag("life")[1].GetComponent<Image>().sprite = lifeLost;
            GameObject.FindGameObjectsWithTag("life")[2].GetComponent<Image>().sprite = lifeLost;
        }
        else if (lives == 2)
        {
            GameObject.FindGameObjectsWithTag("life")[2].GetComponent<Image>().sprite = lifeLost;
        }
        else
        {
            GameObject.FindGameObjectsWithTag("life")[0].GetComponent<Image>().sprite = aliveSprite;
            GameObject.FindGameObjectsWithTag("life")[1].GetComponent<Image>().sprite = aliveSprite;
            GameObject.FindGameObjectsWithTag("life")[2].GetComponent<Image>().sprite = aliveSprite;
        }
    }

    //function to create blocks
    void CreateBlock()
    {
        blkRandNumber = Random.Range(0, 20);
        if (zBlockPosition < 4)
        {
            Instantiate(noPoolObj, new Vector3(0, 0, zBlockPosition), noPoolObj.rotation);
            CreateObjects();
        }
        if (zBlockPosition <= zLimit + 20 && zBlockPosition % 30 != 0)
        {
            if (blkRandNumber < 2)
            {
                Instantiate(poolLeftObj, new Vector3(0, 0, zBlockPosition), poolLeftObj.rotation);
                CreateObjects();
            }
            else if (blkRandNumber >= 4 && blkRandNumber < 6)
            {
                Instantiate(poolRightObj, new Vector3(0, 0, zBlockPosition), poolRightObj.rotation);
                CreateObjects();
            }
            else
            {
                Instantiate(noPoolObj, new Vector3(0, 0, zBlockPosition), noPoolObj.rotation);
                CreateObjects();
            }
        }
        else if (zBlockPosition % 30 == 0 && zBlockPosition != 0)
        {
            CreateBridgePath(zBlockPosition + 6);
            zBlockPosition += 6;
        }
    }

    //create bridge path
    void CreateBridgePath(float position)
    {
        Instantiate(bridgeObj, new Vector3(0, 0, position), bridgeObj.rotation);
    }

    void CreateObjects()
    {
        objRandNumber = Random.Range(0, 46);
        Debug.Log("zBlock" + zBlockPosition + " && objRandNumber = " + objRandNumber);
        if (!(bridge) && zBlockPosition % 25 >= 4)
        {
            if (objRandNumber <= 5)
            {
                Instantiate(coinObj, new Vector3(0, coinObj.position.y, zBlockPosition), coinObj.rotation);
            }
            if (objRandNumber <= 16 && objRandNumber > 10)
            {
                Instantiate(coinObj, new Vector3(-1, coinObj.position.y, zBlockPosition), coinObj.rotation);
            }
            if (objRandNumber > 42)
            {
                Instantiate(coinObj, new Vector3(1, coinObj.position.y, zBlockPosition), coinObj.rotation);
            }
            if (objRandNumber <= 10 && objRandNumber > 5)
            {
                Instantiate(rockObj, new Vector3(0, rockObj.position.y, zBlockPosition), rockObj.rotation);
            }
            if (objRandNumber == 25)
            {
                Instantiate(sugarCubeObj, new Vector3(0, sugarCubeObj.position.y, zBlockPosition), sugarCubeObj.rotation);
            }
            if (objRandNumber == 24)
            {
                Instantiate(sugarCubeObj, new Vector3(1, sugarCubeObj.position.y, zBlockPosition), sugarCubeObj.rotation);
            }
            if (objRandNumber == 23)
            {
                Instantiate(glowCandyObj, new Vector3(0, glowCandyObj.position.y, zBlockPosition), glowCandyObj.rotation);
            }
            if (objRandNumber == 22)
            {
                Instantiate(gumBallObj, new Vector3(-1, gumBallObj.position.y, zBlockPosition), gumBallObj.rotation);
            }
            if (objRandNumber == 21)
            {
                Instantiate(gumBallObj, new Vector3(0, gumBallObj.position.y, zBlockPosition), gumBallObj.rotation);
            }
            if (objRandNumber == 20)
            {
                Instantiate(gumBallObj, new Vector3(1, gumBallObj.position.y, zBlockPosition), gumBallObj.rotation);
            }
            if (objRandNumber == 18)
            {
                Instantiate(chocoBarObj, new Vector3(2, chocoBarObj.position.y, zBlockPosition), chocoBarObj.rotation);
            }
            if (objRandNumber == 19)
            {
                Instantiate(chocoBarObj, new Vector3(-1, chocoBarObj.position.y, zBlockPosition), chocoBarObj.rotation);
            }
        } else if (zBlockPosition % 25 < 4) {
            Instantiate(flagObj, new Vector3(0, flagObj.position.y, zBlockPosition), flagObj.rotation);
        }
        zObjCreate += 2;
    }

    //co-routine for re-enabling collision
    IEnumerator StartCountdown() {
        yield return new WaitForSeconds(2);
        countdown.text = "3";
        yield return new WaitForSeconds(2);
        countdown.text = "2";
        yield return new WaitForSeconds(2);
        countdown.text = "1";
        yield return new WaitForSeconds(2);
        countdown.text = " ";
        startTime = true;
        timeTotal += Time.deltaTime;
        zVelocityFactor = 1;
        GameObject.Find("CharBody(Clone)").GetComponent<Animator>().enabled = true;
    }
}
