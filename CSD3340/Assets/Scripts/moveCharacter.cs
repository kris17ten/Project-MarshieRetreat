using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moveCharacter : MonoBehaviour {
    public KeyCode moveL; //key code to move left
    public KeyCode moveR; //key code to move right

    public float horizontalVelocity = 0; //horizontal velocity of player
    public int laneNumber = 0; //track which lane the player is on
    public float zRespawn = 0; //respawn point for all objects

    public Transform endPlayerObj; //end animation for player

    public string feedbackText = "nothing"; //feedback for user

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        DisplayFeedback(feedbackText);
        //move the player
        GetComponent<Rigidbody>().velocity = new Vector3(horizontalVelocity, 0, 4 * gameManagerScript.zVelocityFactor);

        //left movement
        if (Input.GetKeyDown(moveL) && laneNumber > -1) {
            laneNumber--;
            Vector3 newPos = transform.position;
            newPos.x = laneNumber;
            transform.position = newPos;
        }
        //right movement
		if(Input.GetKeyDown(moveR) && laneNumber < 1) {
            laneNumber++;
            Vector3 newPos = transform.position;
            newPos.x = laneNumber;
            transform.position = newPos;
        }

        //if past the end of course
        if(transform.position.z > gameManagerScript.zLimit) {
            SceneManager.LoadScene("LevelEnd");
        }
    }

    void OnCollisionEnter(Collision other) {
        //allow the character to continue walking normally; avoids collision rotation
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        Vector3 cam = Camera.main.transform.position;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1.25f, cam.z + 3.42f);
        Vector3 newPos = transform.position;
        newPos.x = laneNumber;
        transform.position = newPos;
        
        //collide with obstacle part
        if (other.gameObject.tag == "obstacle") {
            gameManagerScript.lives -= 1;
            gameManagerScript.previousLifeScore += (int)gameObject.transform.position.z;
            Debug.Log("score: " + gameManagerScript.score + " previousLife: " + gameManagerScript.previousLifeScore);

            //if lives are over, game over
            if (gameManagerScript.lives < 1) {
                gameManagerScript.gameRunning = false;
                gameManagerScript.zVelocityFactor = 0;
                Instantiate(endPlayerObj, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), endPlayerObj.rotation);
                Destroy(gameObject, 0.9f);
                gameManagerScript.levelComp = "fail";
                gameManagerScript.startTime = false;
            }
            //otherwise respawn at last checkpoint
            else {
                DestroyBlocks();
                Debug.Log("Character collided! zBlock Reset!");
                gameManagerScript.zBlockPosition = zRespawn;
                laneNumber = 0;
                Camera.main.transform.position = new Vector3(0, 3.71f, -3.42f + zRespawn);
                GameObject.FindGameObjectWithTag("destroyer").transform.position = new Vector3(0, 2, -6 + zRespawn);
                gameObject.transform.position = new Vector3(0, 1.25f, 0 + zRespawn);
                //creatorScript.zObjCreate = zRespawn + 10;
                Debug.Log("Respawned @ " + zRespawn);
            }
        }

        //collide with power up part
        if (other.gameObject.tag == "powerUp") {
            gameManagerScript.powerUpTotal += 1;
            Destroy(other.gameObject);
            if (other.gameObject.name == "Coin(Clone)") { //coin collection
                gameManagerScript.coinTotal += 1;
            }
            if (other.gameObject.name == "CheckPoint(Clone)") { //checkpoint collection
                gameManagerScript.flagTotal += 1;
                float cpZ = other.gameObject.transform.position.z;
                zRespawn = cpZ;
            }
            if (other.gameObject.name == "GlowCandy(Clone)") { //glow candy collection
                gameManagerScript.lives += 1;
                feedbackText = "glowCandy";
                StartCoroutine(Feedback());
                Debug.Log("You got an extra life!");
            }
            if (other.gameObject.name == "SugarCube(Clone)") { //sugar cube collection
                feedbackText = "sugarCube";
                StartCoroutine(Feedback());
                float skip = gameObject.transform.position.z;
                gameObject.transform.position = new Vector3(0, 1.25f, skip + 20);
                Camera.main.transform.position = new Vector3(0, 3.71f, -3.42f + skip + 20);
                gameManagerScript.score += 20;
            }
            if(other.gameObject.name == "GumBall(Clone)") { //gum ball collection
                feedbackText = "gumBall";
                StartCoroutine(Feedback());
                foreach (GameObject o in GameObject.FindGameObjectsWithTag("obstacle"))
                {
                    o.GetComponent<BoxCollider>().enabled = false;
                }
                StartCoroutine(StopCollision());
            }
        }
    }

    //function to destroy all objects in the game (with exception of the character)
    void DestroyBlocks() {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("block")) {
            Destroy(o);
        }
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("obstacle")) {
            Destroy(o);
        }
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("powerUp")) {
            Destroy(o);
        }
    }

    //function for trigger events
    private void OnTriggerEnter(Collider other) {
        //if reached end of the course
        if (other.gameObject.name == "Exit") {
            gameManagerScript.startTime = false;
            SceneManager.LoadScene("LevelEnd");
        }
    }

    //feedback for user on power up
    void DisplayFeedback(string pwr) {
        Text txt = GameObject.Find("Feedback").GetComponent<Text>();
        if(pwr == "glowCandy") {
            txt.text = "A LIFE HAS BEEN RESTORED!";
        } else if(pwr == "sugarCube") {
            txt.text = "SUGAR RUSH!";
        } else if(pwr == "gumBall") {
            txt.text = "YOU HAVE IMMUNITY!";
        } else {
            txt.text = " ";
        }
    }

    //co-routine for re-enabling collision
    IEnumerator StopCollision() {
        yield return new WaitForSeconds(4);
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("obstacle"))
        {
            o.GetComponent<BoxCollider>().enabled = true;
        }
    }

    //co-routine for resetting feedback
    IEnumerator Feedback() {
        yield return new WaitForSeconds(4);
        feedbackText = "nothing";
    }
}
