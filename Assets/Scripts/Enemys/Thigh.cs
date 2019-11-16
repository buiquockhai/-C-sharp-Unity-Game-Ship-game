using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thigh : MonoBehaviour
{
    [SerializeField] AudioSource Audio;
    private Rigidbody2D myBody;
    private int Rot;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        myBody.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        Rot = Random.Range(-2, 2);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Rot * 500 * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
            Instantiate(Audio, transform.parent);

        if (target.tag == "Player" || target.tag == "BotBound" || target.tag == "TopBound")
            Destroy(gameObject, 0.5f);
    }
}
