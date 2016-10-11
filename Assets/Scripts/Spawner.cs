using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float time;
    public string shipType;
    public string behaviour;
    public float speed;
    public float degree;
    public int option;

    public GameObject spawnPoint;

	
	void Update () {

        if (Time.time > time)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load(shipType));

        enemy.transform.position = spawnPoint.transform.position;

        Rigidbody2D body = enemy.GetComponent<Rigidbody2D>();

        EnemyBehaviour script = enemy.GetComponent<EnemyBehaviour>();
        script.behaviour = behaviour;
        script.body = body;
        script.speed = speed;
        script.degree = degree;

        //if (option == 1) ; // Can add other options

        script.Run();
    }
}
