using UnityEngine;
using System.Collections;

public class ShotsMover : MonoBehaviour {
    public float speed;

	void Start () {
        GetComponent<Rigidbody2D>().velocity = (new Vector2(0,1)) * speed;
	}	
	
}
