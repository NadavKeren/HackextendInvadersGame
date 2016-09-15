using UnityEngine;
using System.Collections;

public class AsteroidDestroy : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter2D(Collider2D other)
	{
		/*if (other.tag == "GameBorder") {
			Debug.Log ("Asteroid hit a border");
			return;
		}*/
		Instantiate (explosion , transform.position, transform.rotation);
		if (other.tag == "Player") {
			//Debug.Log ("player collision accured");
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
