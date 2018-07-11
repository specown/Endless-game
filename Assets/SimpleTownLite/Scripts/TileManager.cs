using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = -5.0f;
    private float tileLenght = 10.0f;
    private int amountofTilesOnScreen = 5;
    private float SafeZone = 15.0f;

    private List<GameObject> activeTiles = new List<GameObject>();

	// Use this for initialization
	private void Start () {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        for(int i=0; i<amountofTilesOnScreen; i++)
        {
            SpawnTile();
        }

    }
	
	// Update is called once per frame
	private void Update () {
		if(playerTransform.position.z - SafeZone > (spawnZ - amountofTilesOnScreen * tileLenght))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject gameobj;
        gameobj = Instantiate(tilePrefabs[0]) as GameObject;
        gameobj.transform.SetParent(transform);
        gameobj.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLenght;
        activeTiles.Add(gameobj);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
