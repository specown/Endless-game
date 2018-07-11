using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class AI2 : MonoBehaviour {

	private GameObject player;

	//Initialization
	void Start ()
    {
        //Find player tag
		player = GameObject.FindGameObjectWithTag("Player");

        //Player tag not found
		Debug.Log ("player found");
	}
	
	//Update is called once per frame
	void Update ()
    {
		GetComponent<NavMeshAgent>().destination = player.transform.position;
	}
}
