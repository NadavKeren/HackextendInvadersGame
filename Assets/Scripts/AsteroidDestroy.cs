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
		if (other.gameObject.tag == "Player") {
			//Debug.Log ("player collision accured");
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}

		Destroy (other.gameObject);
		Destroy (gameObject);

		//System.Threading.Thread.Sleep (191);
		//Destroy (explosion);
		//}
	}
}
