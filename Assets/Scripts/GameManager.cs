using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public GameObject playerPrefab;
    public int NumberOfPlayers;
	public static GameManager instance = null;
    private Dictionary<GameObject, int> players;
    public GameObject[] playerSpawners;
    private List<List<bool> > collisionMatrix; 
	void Awake () {

		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		Time.fixedDeltaTime = (float)0.008;

		DontDestroyOnLoad (gameObject);
        players = new Dictionary<GameObject, int>();
	}

	// Use this for initialization
	void Start () {
        //HardCoded Shit
        for (int i = 0; i < NumberOfPlayers; i++)
        {
            GameObject p = Instantiate(playerPrefab, playerSpawners[Random.Range(0, playerSpawners.GetLength(0))].transform.position, Quaternion.identity) as GameObject;
            players.Add(p, i);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
