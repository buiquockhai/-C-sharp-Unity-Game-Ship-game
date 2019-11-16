using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField] AudioSource myAudio;
    float speed = 2;

    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(myBody.velocity.x, -speed);
        Vector3 temp = transform.position;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
            Instantiate(myAudio, transform.parent);
        if (target.tag == "BotBound" || target.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
