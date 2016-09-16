using UnityEngine;
using System.Collections;

public class AsteroidDestroy : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnCollisionEnter2D(Collision2D other)
	{
		/*if (other.tag == "GameBorder") {
			Debug.Log ("Asteroid hit a border");
			return;
		}*/

		//if (other.gameObject.tag != "Enemy") {
			Instantiate (explosion, transform.position, transform.rotation);
		
		//Debug.Log ("COLLISION ACCURED"+other.gameObject.tag);
		GameObject lvlCtrlObject = GameObject.FindWithTag ("LevelController");
		LevelController lvlCtrl = lvlCtrlObject.GetComponent<LevelController>();

		if (other.gameObject.tag == "Player") {
			//Debug.Log ("player collision accured");
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			lvlCtrl.GameOver ();
		}
		else
		{
			lvlCtrl.AddScore (100);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);

		//System.Threading.Thread.Sleep (191);
		//Destroy (explosion);
		//}
	}
}
