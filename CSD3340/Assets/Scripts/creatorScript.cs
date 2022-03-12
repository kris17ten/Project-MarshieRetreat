using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatorScript : MonoBehaviour
{
    //    //all objects to be instantiated
    //    public Transform sugarCubeObj;
    //    public Transform gumBallObj;
    //    public Transform glowCandyObj;
    //    public Transform coinObj;
    //    public Transform flagObj;
    //    public Transform chocoBarObj;
    //    public Transform rockObj;

    //    public static int objRandNumber; //object random number
    //    public static float zObjCreate; //move position of the creator to create objects

    //    // Use this for initialization
    //    void Start () {
    //        Vector3 newPos = transform.position;
    //        newPos.z = GameObject.Find("CharBody(Clone)").transform.position.z + 20;
    //        transform.position = newPos;

    //        zObjCreate = transform.position.z;
    //    }

    //	// Update is called once per frame
    //	void Update () {
    //        //if not yet reached the limit, create object
    //        if (zObjCreate < gameManagerScript.zLimit) {
    //            //CreateObjects();
    //        }

    //        Vector3 newPos2 = transform.position;
    //        newPos2.z = zObjCreate;
    //        transform.position = newPos2;
    //    }

    //    //trigger manipulation
    //    private void OnTriggerEnter(Collider other) {
    //        if (other.gameObject.name == "BridgeEnter")
    //        {
    //            Debug.Log("Bridge entered!");
    //            gameManagerScript.bridge = true;
    //            Debug.Log("Trigger -> " + gameManagerScript.bridge);
    //        }
    //        if (other.gameObject.name == "BridgeExit")
    //        {
    //            Debug.Log("Bridge exited!");
    //            gameManagerScript.bridge = false;
    //            Debug.Log("Trigger -> " + gameManagerScript.bridge);
    //        }
    //    }

    //    //function to create objects
    //    void CreateObjects() {
    //        objRandNumber = Random.Range(0, 51);
    //        if (!(gameManagerScript.bridge) && gameManagerScript.zBlockPosition % 25 >= 4) {
    //            if (objRandNumber <= 5) {
    //                Instantiate(coinObj, new Vector3(0, coinObj.position.y, zObjCreate), coinObj.rotation);
    //            }
    //            if (objRandNumber <= 16 && objRandNumber > 10) {
    //                Instantiate(coinObj, new Vector3(-1, coinObj.position.y, zObjCreate), coinObj.rotation);
    //            }
    //            if (objRandNumber > 42) {
    //                Instantiate(coinObj, new Vector3(1, coinObj.position.y, zObjCreate), coinObj.rotation);
    //            }
    //            if (objRandNumber <= 10 && objRandNumber > 5) {
    //                Instantiate(rockObj, new Vector3(0, rockObj.position.y, zObjCreate), rockObj.rotation);
    //            }
    //            if(objRandNumber == 25) {
    //                Instantiate(sugarCubeObj, new Vector3(0, sugarCubeObj.position.y, zObjCreate), sugarCubeObj.rotation);
    //            }
    //            if (objRandNumber == 24) {
    //                Instantiate(sugarCubeObj, new Vector3(1, sugarCubeObj.position.y, zObjCreate), sugarCubeObj.rotation);
    //            }
    //            if (objRandNumber == 23) {
    //                Instantiate(glowCandyObj, new Vector3(0, glowCandyObj.position.y, zObjCreate), glowCandyObj.rotation);
    //            }
    //            if (objRandNumber == 22) {
    //                Instantiate(gumBallObj, new Vector3(-1, gumBallObj.position.y, zObjCreate), gumBallObj.rotation);
    //            }
    //            if (objRandNumber == 21) {
    //                Instantiate(gumBallObj, new Vector3(0, gumBallObj.position.y, zObjCreate), gumBallObj.rotation);
    //            }
    //            if (objRandNumber == 20) {
    //                Instantiate(gumBallObj, new Vector3(1, gumBallObj.position.y, zObjCreate), gumBallObj.rotation);
    //            }
    //            if (objRandNumber == 18) {
    //                Instantiate(chocoBarObj, new Vector3(2, chocoBarObj.position.y, zObjCreate), chocoBarObj.rotation);
    //            }
    //            if (objRandNumber == 19) {
    //                Instantiate(chocoBarObj, new Vector3(-1, chocoBarObj.position.y, zObjCreate), chocoBarObj.rotation);
    //            }
    //            else {
    //                zObjCreate += 1;
    //                Vector3 newPos2 = transform.position;
    //                newPos2.z = zObjCreate;
    //                transform.position = newPos2;
    //            }
    //        } else if (gameManagerScript.zBlockPosition % 25 < 4) {
    //            Instantiate(flagObj, new Vector3(0, flagObj.position.y, zObjCreate), flagObj.rotation);
    //        }
    //        zObjCreate += 2;
    //    }
}
