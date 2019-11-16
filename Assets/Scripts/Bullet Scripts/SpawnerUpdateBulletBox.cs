using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerUpdateBulletBox : MonoBehaviour
{    
    public GameObject[] typeBox;
    private BoxCollider2D Box;

    private void Awake()
    {
        Box = GetComponent<BoxCollider2D>();
    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnUpdateBulletBox());
    }

    IEnumerator SpawnUpdateBulletBox()
    {
        yield return new WaitForSeconds(Random.Range(5f, 6f));

        float minX = -Box.bounds.size.x / 2f;
        float maxX = Box.bounds.size.x / 2f;
        Vector3 Temp = transform.position;
        Temp.x = Random.Range(minX, maxX);
        int type = Random.Range(0, 3);
        Instantiate(typeBox[type], Temp, Quaternion.identity);
        StartCoroutine(SpawnUpdateBulletBox());
    }
}
