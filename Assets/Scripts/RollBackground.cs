using UnityEngine;
using System.Collections;

public class RollBackground : MonoBehaviour {

	public float scrollSpeed;
	private Vector2 startPosition;
	private Vector2 newPosition;

	void Start () {
		startPosition = transform.position;
		newPosition = startPosition;
	}

	void Update () {
		if(newPosition.y > -50)
		{
			newPosition = newPosition + (new Vector2 (0.0f, -1.0f)) * scrollSpeed * 0.001f ;
			transform.position = newPosition;
		}
	}
}
