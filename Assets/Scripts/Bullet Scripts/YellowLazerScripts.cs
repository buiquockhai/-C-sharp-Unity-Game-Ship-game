using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLazerScripts : MonoBehaviour {

    private float bulletSpeed;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (PlayerController.currentTypeBullet == "YellowBullet")
        {
            bulletSpeed = 10;
        }
        else if (PlayerController.currentTypeBullet == "BlueBullet")
        {
            bulletSpeed = 6;
        }
        else
        {
            bulletSpeed = 16;
        }
        rb.velocity = new Vector2(rb.velocity.x, bulletSpeed);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "TopBound")
        {
            Destroy(gameObject);
        }
    }
}
