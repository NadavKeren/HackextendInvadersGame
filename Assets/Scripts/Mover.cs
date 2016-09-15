using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	void Start () {
		gameObject.GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
	}

}
