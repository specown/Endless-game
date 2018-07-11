using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class GameSetup : MonoBehaviour {

	public GameObject enemy;
	public Button dumbStartButton;
	public Button smartStartButton;
	private bool buttononce = false;

	// Use this for initialization
	void Start ()
    {
        //Put scripts to false until game mode is chosen
		enemy.GetComponent<AI2> ().enabled = false;
		enemy.GetComponent<CarAIControl> ().enabled = false;
	}
	
	//Update is called once per frame
	void Update ()
    {
        //Check if button was not pressed previously
		if (!buttononce)
        {
            //Add listenets to game mode buttons
			dumbStartButton.onClick.AddListener (DumbGameMode);
			smartStartButton.onClick.AddListener (SmartGameMode);

            //Ensure that button was pressed once only
			buttononce = true;
		}
	}

	void SmartGameMode()
    {
        //If chosen Intelligent enemy player game mode - enable AI2 script
		enemy.GetComponent<AI2> ().enabled = true;
		Debug.Log ("smart mode");
	}

	void DumbGameMode()
    {
        //If chosen dumb enemy player game mode - enable CarAIControl script
		enemy.GetComponent<CarAIControl> ().enabled = true;
		Debug.Log ("dumb mode");
	}
}
