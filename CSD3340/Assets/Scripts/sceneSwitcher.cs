using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //function to start game
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    //function to restart game
    public void RestartGame()
    {
        stats.RestartGame();
        SceneManager.LoadScene("StartScene");
        Debug.Log("Game is restarting...");
    }

    //function to quit game
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting...");
    }
}
