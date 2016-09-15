using UnityEngine;
using System.Collections;

public class BordersController : MonoBehaviour {

	void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}