using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public Transform[] spawnPoints;
	public Text scoreText;
	private double scoreTime;
	public GameObject GameOverPanel;
	private bool opened = false;
	public InputField InputName;
	public Button SubmitButton;

	public int enemyIncreaseMultiplier = 2;
	public double enemyIncreaseTime = 20;
	public int maxEnemies = 20;
	private int enemyCount = 0;
	public int initialEnemyCount = 3;
	private double increaseLastTime;
	private bool onetime = false;

	//Initialization
	void Start ()
    {
        //Used to activate and displayer score for the player
		scoreText.alignment = TextAnchor.MiddleCenter;
		scoreTime = Time.deltaTime;
		scoreText.gameObject.SetActive(true);

	}

	//Update is called once per frame
	void Update ()
    {	
        //Update score if game started
		if (!opened)
        {
			scoreTime += Time.deltaTime;
		}

        //Reformat score text
		scoreText.text = scoreTime.ToString("0.00");

		if (!onetime)
        {
			if (!GameObject.FindGameObjectWithTag("Player"))
            {
				opened = true;
				DisplayPanel ();
				SaveLogic ();
				onetime = true;
			}
		}

        //Used to spawn enemies / increase enemy count
			WaveSpawner ();
	}

	void SaveLogic()
    {
        
        //Get high scores
		List<Highscore> scores = GetComponent<Save> ().getHighscores ();
		Debug.Log (scores.Count);

        //Count how many scores we got in the file
		if (scores.Count <= 2) {
			Debug.Log ("list is empty or only 2 items");
			SubmitButton.onClick.AddListener (SaveScore);
			return;
		}
        else if (scoreTime > scores[2].score)
        {
			Debug.Log ("has scores");
			SubmitButton.onClick.AddListener (SaveScore);
			return;
		}
        //Player did not survive for long enough
        else {
			Debug.Log ("low score");
            //Alow adding score to high scores
			InputName.gameObject.SetActive (false);
			SubmitButton.gameObject.SetActive (false);
			return;
		}
	}

	void SaveScore()
    {
        //Player has survived longer than others, get his details and save details to file
		Highscore highscore = new Highscore(InputName.text, scoreTime);
		GetComponent<Save>().SaveFile(highscore);
		SubmitButton.interactable = false;

		Debug.Log ("save");
	}

    //If player was catches - show Game Over Panel
	void DisplayPanel()
    {
		GameOverPanel.gameObject.SetActive(true);
	}
		

	void SpawnEnemy(int number)
    {
        //Used to check previous spawn index
		int prevSpawnPointIndex = -1;

        //Check if we got enemy players attached
		if(enemy != null)
        {
            //Check how many enemies we should spawn, if null then assign 1
			if(number == null)
            {
				number = 1;
			}

			for(int i = 0; i <= number; i++)
            {
                //Generate random spawn point index to the range of maximum spawn points
				int spawnPointIndex = Random.Range (0, spawnPoints.Length);

                //If generated number is equal to previous place where enemy was spawned then generate a new number
				while (prevSpawnPointIndex == spawnPointIndex)
                { 
					spawnPointIndex = Random.Range (0, spawnPoints.Length);
				}

                //Create enemy
				Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

                //Memorize where we spawned the enemies
				prevSpawnPointIndex = spawnPointIndex;
			}
		}
        //We haven't got any enemies attached
        else
        {
			Debug.Log("Enemy is not defined!");
		}
	}


	void WaveSpawner()
    {
        //If we haven't got any enemies
		if(enemyCount == 0)
        {
            //Spawn enemy with predefined initial enemy count
			SpawnEnemy(initialEnemyCount);
            //Assign enemy count to variable
			enemyCount = initialEnemyCount;

            //Check what time enemies were added
            increaseLastTime = scoreTime;
		}
        
        //Check if we need to increase enemy count and maximum number of enemies will not be reached if increase
		else if((scoreTime - increaseLastTime) >= enemyIncreaseTime && (GameObject.FindGameObjectsWithTag("Enemy").Length * enemyIncreaseMultiplier) < 20)
        {
            //Increase enemy number
			enemyCount *= enemyIncreaseMultiplier;

            //Spawn enemies
			SpawnEnemy(enemyCount);

            //Check what time enemies were added
			increaseLastTime = scoreTime;
		}
	}
}
