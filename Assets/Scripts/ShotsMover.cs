using UnityEngine;
using System.Collections;

public class ShotsMover : MonoBehaviour {
    public float speed;

	void Start () {
        GetComponent<Rigidbody>().velocity = (new Vector3(0.0f,1.0f,0.0f)) * speed;
	}	
	
}
