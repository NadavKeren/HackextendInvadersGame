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
    private new SpriteRenderer renderer;

    private int moveX;
    private int moveY;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    // Use this for initialization
    void Start () {

        Screen.SetResolution(resWidth, resHeight, true);

        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();

        minX = -9 + renderer.bounds.extents.x;
        maxX = 9 - renderer.bounds.extents.x;
        minY = -5 + renderer.bounds.extents.y;
        maxY = 5 - renderer.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
        /*Vector3 pos = body.position; //replaced transform.position
        if (Input.GetKey(KeyCode.UpArrow))
            ChangePosition(new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime));
        if (Input.GetKey(KeyCode.DownArrow))
            ChangePosition(new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime));
        if (Input.GetKey(KeyCode.RightArrow))
            ChangePosition(new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y));
        if (Input.GetKey(KeyCode.LeftArrow))
            ChangePosition(new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y));*/


        /*if (Input.GetKey(KeyCode.UpArrow))
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);*/


    }

    private void FixedUpdate()
    {
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

        body.velocity = new Vector2(moveX, moveY) * speed;

        Vector3 pos = body.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        body.position = pos;
    }

    private void ChangePosition(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        body.position = pos;
    }

    void FireWeapon()
    {

    }
}