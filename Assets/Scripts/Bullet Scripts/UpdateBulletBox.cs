using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBulletBox : MonoBehaviour {

    [SerializeField] AudioSource myAudio;

    public float speedBox;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, -speedBox);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
            Instantiate(myAudio, transform.parent);
        if (target.tag == "BotBound")
        {
            Destroy(gameObject);
        }
    }
}
