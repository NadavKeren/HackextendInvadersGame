using UnityEngine;
using System.Collections;

public class AsteroidMover : MonoBehaviour {
    
	public float speed;

	private Vector2 velocity;
	private Rigidbody2D rb2D;

	void Start () {
		velocity = new Vector2 (0f, speed);
		rb2D = gameObject.GetComponent<Rigidbody2D> ();
	}	

	void FixedUpdate(){
		rb2D.MovePosition (rb2D.position + velocity * Time.fixedDeltaTime);
	}
	
}
