using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour {

	public Text First;
	public Text Second;
	public Text Third;

	//Initialization
	void Awake ()
    {
        //Get high score file
		List<Highscore> scores = GetComponent<Save> ().getHighscores ();
		Debug.Log (scores);

        //Used to display top 3 players from saved game file
        First.text = "1. Name: " + scores [0].name + "\nScore: " + scores [0].score.ToString("0.00");
        Second.text = "2. Name: " + scores [1].name + "\nScore: " + scores [1].score.ToString("0.00");
		Third.text = "3. Name: " + scores [2].name + "\nScore: " + scores [2].score.ToString("0.00");
	}

}
