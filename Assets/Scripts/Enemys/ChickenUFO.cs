using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenUFO : MonoBehaviour
{
    [SerializeField] private GameObject egg;
    [SerializeField] private GameObject thigh;
    [SerializeField] private GameObject gift;
    [SerializeField] AudioSource myAudio;
    private int heal = 150, count = 150;

    private Rigidbody2D myBody;
    private float speed = 2;
    private float x, y;

    void Start()
    {
        StartCoroutine(eggChicken());
        StartCoroutine(MoveBoss());
    }

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    IEnumerator MoveBoss()
    {
        x = y = Random.Range(-0.5f, 0.5f);

        if (transform.position.x < -5.5 || transform.position.x > 5.5)
            if (transform.position.x < -5.5)
                x = Random.Range(0.5f, 1);
            else
                x = -1 * Random.Range(0.5f, 1);
        if (transform.position.y < -3 || transform.position.y > 3)
            if (transform.position.y < -3)
                y = Random.Range(0.5f, 1);
            else
                y = -1 * Random.Range(0.5f, 1);

        myBody.velocity = new Vector2(speed * x, speed * y);

        yield return new WaitForSeconds(Random.Range(2, 3));
        StartCoroutine(MoveBoss());
    }

    IEnumerator eggChicken()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        Vector3 temp = transform.position;
        temp.x += Random.Range(-1f, 1f);
        temp.y -= 1f;
        Instantiate(egg, temp, Quaternion.identity);
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
                for (int i = 0; i < 4; i++)
                    Instantiate(thigh, transform.position, Quaternion.identity);
                Instantiate(gift, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
