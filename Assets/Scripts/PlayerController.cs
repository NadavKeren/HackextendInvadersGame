using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private int speed;

    [SerializeField]
    private int resWidth;
    [SerializeField]
    private int resHeight;

    private Rigidbody2D body;
    private int moveX;
    private int moveY;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();

        Screen.SetResolution(resWidth, resHeight, true);
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKey(KeyCode.UpArrow))
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
            */
        if (Input.GetKey(KeyCode.UpArrow))
            moveY = 1;
        else if (Input.GetKey(KeyCode.DownArrow))
            moveY = -1;
        else moveY = 0;
        if (Input.GetKey(KeyCode.RightArrow))
            moveX = 1;
        else if (Input.GetKey(KeyCode.LeftArrow))
            moveX = -1;
        else moveX = 0;
        if (Input.GetKey(KeyCode.Space))
            FireWeapon();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(moveX * speed, moveY * speed);
    }

    void FireWeapon()
    {

    }
}