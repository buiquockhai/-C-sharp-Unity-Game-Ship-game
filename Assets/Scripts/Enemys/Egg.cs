using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {

    float speed = 2;

    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        Vector3 temp = transform.position;
        temp.z = 0;
        transform.position = temp;
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(myBody.velocity.x, -speed);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "BotBound" || target.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
