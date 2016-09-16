using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    private bool[] enemyCreationBoolean;
    private int enemiesCounter;


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

    // Use this for initialization
    void Start () {

        // Set max number of enemies
        int numberOfEnemies = 30;

        enemyCreationBoolean = new bool[numberOfEnemies];
        enemyCreationBoolean[0] = true;
        for (int i = 1; i < enemyCreationBoolean.Length; i++)
        {
            enemyCreationBoolean[i] = false;
        }
        enemiesCounter = 0;

		score = 0;
		gameOver = false;
		restart = false;
		scoreText.text = "Score: 0";
		gameOverText.text = "";
		restartText.text = "";
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}

        if (Time.time > 3 && enemyCreationBoolean[0])
        {
            createEnemy(0, "EasyShip", "normal", 3, 180);
            enemyCreationBoolean[enemiesCounter] = false;
            enemyCreationBoolean[enemiesCounter + 1] = true;
            enemiesCounter++;
        }
        else if (Time.time > 4 && enemyCreationBoolean[1])
        {
            createEnemy(3, "EasyShip", "normal", 3, 180);
            enemyCreationBoolean[enemiesCounter] = false;
            enemyCreationBoolean[enemiesCounter + 1] = true;
            enemiesCounter++;
        }
        else if (Time.time > 5 && enemyCreationBoolean[2])
        {
            createEnemy(1, "EasyShip", "normal", 3, 180);
            enemyCreationBoolean[enemiesCounter] = false;
            enemyCreationBoolean[enemiesCounter + 1] = true;
            enemiesCounter++;
        }
        else if (Time.time > 6 && enemyCreationBoolean[3])
        {
            createEnemy(2, "EasyShip", "normal", 5, 180);
            enemyCreationBoolean[enemiesCounter] = false;
            enemyCreationBoolean[enemiesCounter + 1] = true;
            enemiesCounter++;
        }
        else if (Time.time > 7 && enemyCreationBoolean[4])
        {
            createEnemy(4, "EasyShip", "normal", 4, 220);
            enemyCreationBoolean[enemiesCounter] = false;
            enemyCreationBoolean[enemiesCounter + 1] = true;
            enemiesCounter++;
        }
        else if (Time.time > 8 && enemyCreationBoolean[5])
        {
            createEnemy(5, "HardShip", "normal", 3, 90);
            enemyCreationBoolean[enemiesCounter] = false;
            enemyCreationBoolean[enemiesCounter + 1] = true;
            enemiesCounter++;
        }

		else if (Time.time > 9 && enemyCreationBoolean[6])
		{
			createEnemy(0, "Asteroid", "normal", 2, 180);
			enemyCreationBoolean[enemiesCounter] = false;
			enemyCreationBoolean[enemiesCounter + 1] = true;
			enemiesCounter++;
		}
		else if (Time.time > 11 && enemyCreationBoolean[7])
		{
			createEnemy(4, "EasyShip", "normal", 3, 270);
			enemyCreationBoolean[enemiesCounter] = false;
			enemyCreationBoolean[enemiesCounter + 1] = true;
			enemiesCounter++;
		}
		else if (Time.time > 11 && enemyCreationBoolean[8])
		{
			createEnemy(5, "EasyShip", "normal", 3, 90);
			enemyCreationBoolean[enemiesCounter] = false;
			enemyCreationBoolean[enemiesCounter + 1] = true;
			enemiesCounter++;
		}
		else if (Time.time > 15 && enemyCreationBoolean[9])
		{
			createEnemy(0, "Asteroid", "normal", 2, 180);
			enemyCreationBoolean[enemiesCounter] = false;
			enemyCreationBoolean[enemiesCounter + 1] = true;
			enemiesCounter++;
		}
		else if (Time.time > 15 && enemyCreationBoolean[10])
		{
			createEnemy(1, "Asteroid", "normal", 2, 180);
			enemyCreationBoolean[enemiesCounter] = false;
			enemyCreationBoolean[enemiesCounter + 1] = true;
			enemiesCounter++;
		}
		else if (Time.time > 16 && enemyCreationBoolean[11])
		{
			createEnemy(3, "Asteroid", "normal", 2, 180);
			enemyCreationBoolean[enemiesCounter] = false;
			enemyCreationBoolean[enemiesCounter + 1] = true;
			enemiesCounter++;
		}
		else if (Time.time > 17 && enemyCreationBoolean[12])
		{
			createEnemy(2, "Asteroid", "normal", 2, 180);
			enemyCreationBoolean[enemiesCounter] = false;
			enemyCreationBoolean[enemiesCounter + 1] = true;
			enemiesCounter++;
		}
    }

    private void createEnemy(int spawnPoint, string shipType, string behaviour, float speed, float degree, int option = 1)
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load(shipType));

        if (spawnPoint == 0)
            enemy.transform.position = spawn0.transform.position;
        else if (spawnPoint == 1)
            enemy.transform.position = spawn1.transform.position;
        else if (spawnPoint == 2)
            enemy.transform.position = spawn2.transform.position;
        else if (spawnPoint == 3)
            enemy.transform.position = spawn3.transform.position;
        else if (spawnPoint == 4)
            enemy.transform.position = spawn4.transform.position;
        else if (spawnPoint == 5)
            enemy.transform.position = spawn5.transform.position;
        else if (spawnPoint == 6)
            enemy.transform.position = spawn6.transform.position;

        Rigidbody2D body = enemy.GetComponent<Rigidbody2D>();

        EnemyBehaviour script = enemy.GetComponent<EnemyBehaviour>();
        script.behaviour = behaviour;
        script.body = body;
        script.speed = speed;
        script.degree = degree;
        script.Run();
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
		gameOver = true;
	}
}