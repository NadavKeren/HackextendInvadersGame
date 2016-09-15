using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Set Player speed
    [SerializeField]
    private int speed;    

    // Set screen resolution
    [SerializeField]
    private int resWidth;
    [SerializeField]
    private int resHeight;

    private Rigidbody2D body;
    private new SpriteRenderer renderer;

    // Movement
    private int moveX;
    private int moveY;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    // Shooting
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

	// Use this for initialization
	void Start () {

        Screen.SetResolution(resWidth, resHeight, true);

        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();

        minX = -9 + renderer.bounds.extents.x;
        maxX = 9 - renderer.bounds.extents.x;
        minY = -5 + renderer.bounds.extents.y;
        maxY = 5 - renderer.bounds.extents.y;

        secondaryRate = 0.5f * fireRate;
	}
	
	// Update is called once per frame
	void Update () {
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

        body.velocity = new Vector2(moveX, moveY) * speed;

        Vector3 pos = body.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        body.position = pos;
    }

    void fireMainWeapon()
    {
        nextMain = Time.time + fireRate;
        Instantiate(mainShot, shotSpawn.position, Quaternion.Euler(0, 0, 0));
    }
    void fireSecondaryWeapon()
    {
        nextSecondary = Time.time + secondaryRate;
        leftSecond = Instantiate(secondaryShot, leftWing.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        rightSecond = Instantiate(secondaryShot, rightWing.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        isSecondShot = true;
    }
}