using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private float delay = 0.15f;

	void Start () {
		Destroy (gameObject, this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length + delay);
	}

}
