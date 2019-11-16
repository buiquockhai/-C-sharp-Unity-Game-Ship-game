using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedlazerScripts : MonoBehaviour {

    public float bulletSpeed;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(0f, -bulletSpeed);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BottomDestroy")
        {
            Destroy(gameObject);
        }
    }
}
