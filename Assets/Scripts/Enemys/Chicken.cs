using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chicken : MonoBehaviour
{
    [SerializeField] private GameObject egg;
    [SerializeField] private GameObject thigh;
    [SerializeField] private GameObject PowerUp;
    [SerializeField] AudioSource myAudio;
    private int heal = 2;

    void Start()
    {
        StartCoroutine(eggChicken());
    }

    IEnumerator eggChicken()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        Vector3 temp = transform.position;
        temp.y -= 0.5f;
        Instantiate(egg, temp, Quaternion.identity);
        StartCoroutine(eggChicken());
    }
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet" || target.tag == "Player")
        {
            heal -= 1;
            if (heal < 1)
            {
                Instantiate(myAudio, transform.parent);
                if (Random.Range(0f, 6f) < 1)
                    Instantiate(PowerUp, transform.position, Quaternion.identity);
                Instantiate(thigh, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
