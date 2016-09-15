using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "GameBorder") {
			return;
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
