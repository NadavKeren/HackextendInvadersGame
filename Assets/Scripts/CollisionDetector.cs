using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

    public GameObject playerExplosion;
    public GameObject selfExplosion;

	void OnCollisionEnter2D(Collision2D other)
	{
		Instantiate (selfExplosion, transform.position, transform.rotation);

		GameObject lvlCtrlObject = GameObject.FindWithTag ("LevelController");
		LevelController lvlCtrl = lvlCtrlObject.GetComponent<LevelController>();

		if (other.gameObject.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			lvlCtrl.GameOver ();
		}
		else
		{
            if (gameObject.name == "EasyShip")
			    lvlCtrl.AddScore (100);
            else if (gameObject.name == "HardShip")
                lvlCtrl.AddScore(500);
            else if (gameObject.name == "Asteroid")
                lvlCtrl.AddScore(100);
        }
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
