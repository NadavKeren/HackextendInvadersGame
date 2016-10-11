using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text gameOverText;
	[SerializeField]
	private Text restartText;

	private int score;
	private bool restart;
	private bool gameOver;


    [SerializeField]
    private GameObject spawn0;
    [SerializeField]
    private GameObject spawn1;
    [SerializeField]
    private GameObject spawn2;
    [SerializeField]
    private GameObject spawn3;
    [SerializeField]
    private GameObject spawn4;
    [SerializeField]
    private GameObject spawn5;
    [SerializeField]
    private GameObject spawn6;

    private GameObject[] spawners;
    int enemiesCounter;


    // Use this for initialization
    void Start () {

        // Game initialization
		score = 0;
		gameOver = false;
		restart = false;
		scoreText.text = "Score: 0";
		gameOverText.text = "";
		restartText.text = "";

        enemiesCounter = 0;


        //
        // Level Setup
        //

        // Set max number of enemies
        // Make sure the number is bigger than the number of 'CreateSpawn' lines below
        int numberOfEnemies = 30;
        spawners = new GameObject[numberOfEnemies];

        // Each line represents spawning of an enemy
        CreateSpawn(3, "EasyShip", spawn0, "normal", 3, 180);
        CreateSpawn(4, "EasyShip", spawn3, "normal", 3, 180);
        CreateSpawn(5, "EasyShip", spawn1, "normal", 3, 180);
        CreateSpawn(6, "EasyShip", spawn2, "normal", 5, 180);
        CreateSpawn(7, "EasyShip", spawn4, "normal", 4, 220);
        CreateSpawn(8, "HardShip", spawn5, "normal", 3, 90);
        CreateSpawn(9, "Asteroid", spawn0, "normal", 2, 180);
    }

    private void CreateSpawn(float time, string shipType, GameObject spawnPoint, string behaviour, float speed, float degree, int option = 1)
    {
        
        spawners[enemiesCounter] = (GameObject)Instantiate(Resources.Load("Spawner"));
        Spawner spawnerDetails = spawners[enemiesCounter].GetComponent<Spawner>();
        spawnerDetails.time = time;
        spawnerDetails.shipType = shipType;
        spawnerDetails.spawnPoint = spawnPoint;
        spawnerDetails.behaviour = behaviour;
        spawnerDetails.speed = speed;
        spawnerDetails.degree = degree;
        spawnerDetails.option = option;

        enemiesCounter++;
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
    }

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over! :(";
        restartText.text = "Press ESC to quit";
        gameOver = true;
	}
}