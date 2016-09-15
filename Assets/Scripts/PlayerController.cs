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
    public GameObject mainShot;
    public GameObject secondaryShot;
    public Transform shotSpawn;
    public Transform leftWing;
    public Transform rightWing;
    [SerializeField]
    public float fireRate;
    private float secondaryRate;

    private float nextMain;
    private float nextSecondary;
    private bool isSecondShot = false;
    private GameObject leftSecond;
    private GameObject rightSecond;

    void fireMainWeapon()
    {
        nextMain = Time.time + fireRate;
        Instantiate(mainShot, shotSpawn.position, Quaternion.Euler(0,0,0));
    }
    void fireSecondaryWeapon()
    {
        nextSecondary = Time.time + secondaryRate;
        leftSecond = Instantiate(secondaryShot, leftWing.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        rightSecond = Instantiate(secondaryShot, rightWing.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        isSecondShot = true;
    }
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        Screen.SetResolution(resWidth, resHeight, true);
        secondaryRate = 0.5f * fireRate;
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
        if (Input.GetKey(KeyCode.Space) && Time.time > nextMain)
            fireMainWeapon();
        if (Input.GetKey(KeyCode.LeftControl))
            fireSecondaryWeapon();
        else if (isSecondShot)
        {
            GameObject.Destroy(leftSecond,1);
            GameObject.Destroy(rightSecond,1);
            isSecondShot = false;
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(moveX * speed, moveY * speed);
    }    
}