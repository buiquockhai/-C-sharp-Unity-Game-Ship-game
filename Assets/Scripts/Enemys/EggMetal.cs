using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMetal : MonoBehaviour
{
    [SerializeField] private GameObject Egg;
    [SerializeField] private GameObject gift;
    [SerializeField] AudioSource myAudio;

    private int heal = 400, count = 400;

    private Rigidbody2D myBody;
    private float speed = 2;
    private int Rot = 1;

    void Start()
    {
        StartCoroutine(eggChicken());
        StartCoroutine(MoveBoss());
        StartCoroutine(RotateBoss());
    }

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove) StartCoroutine(MoveBoss_2());
        transform.Rotate(new Vector3(0, 0, Rot * 100 * Time.deltaTime));
    }

    bool canMove = false;
    IEnumerator MoveBoss()
    {
        myBody.velocity = new Vector2(0, -speed);
        yield return new WaitForSeconds(2.55f);
        myBody.velocity = new Vector2(0, 0);
        canMove = true;
    }

    IEnumerator RotateBoss()
    {
        Rot = Random.Range(-3, 3);
        yield return new WaitForSeconds(1.5f);
        GameObject egg;
        Rigidbody2D body_egg;
        for (int i = 0; i < 5; i++)
        {
            egg = Instantiate(Egg, transform.position, Quaternion.identity);
            body_egg = egg.GetComponent<Rigidbody2D>();
            float x = 0.75f * (i - 5 / 2);
            body_egg.velocity = new Vector2(x, 0);
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(RotateBoss());
    }

    float t = 2.8f;
    float speedMove = 1.7f;
    IEnumerator MoveBoss_2()
    {
        myBody.velocity = new Vector2(speedMove, 0);
        speedMove *= -1;
        if (t <= speedMove * 2) t *= 2;
        canMove = false;
        yield return new WaitForSeconds(t);
        canMove = true;
    }

    IEnumerator eggChicken()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 1f));
        Vector3 temp = transform.position;
        temp.x += Random.Range(-1.5f, 1.5f);
        temp.y -= 1f;
        Instantiate(Egg, temp, Quaternion.identity);
        StartCoroutine(eggChicken());
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet" || target.tag == "Player")
        {
            if (count - heal > 50)
            {
                Instantiate(myAudio, transform.parent);
                count -= 50;
            }
            if (PlayerController.currentTypeBullet == "YellowBullet")
            {
                heal -= 2;
            }
            else if (PlayerController.currentTypeBullet == "BlueBullet")
            {
                heal -= 3;
            }
            else
            {
                heal -= 1;
            }
            if (heal < 1)
            {
                Vector3 temp = transform.position;
                for (int i = 0; i < 3; i++)
                {
                    temp.x = Random.Range(-1.5f, 1.5f);
                    Instantiate(gift, temp, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
}
