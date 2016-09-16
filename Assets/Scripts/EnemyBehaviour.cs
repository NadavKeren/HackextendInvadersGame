using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public string behaviour;
    public Rigidbody2D body;
    public float degree;
    public float speed;

    public void Run()
    {
        if (behaviour.Equals("normal"))
        {
            body.velocity = (Vector2)(Quaternion.Euler(0, 0, degree) * Vector2.up) * speed;
        }
    }
}
