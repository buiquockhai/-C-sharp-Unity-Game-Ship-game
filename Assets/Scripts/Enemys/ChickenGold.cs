using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenGold : MonoBehaviour
{

    float speed = 3;

    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        StartCoroutine(End());
    }

    void Update()
    {
        if (myBody.transform.position.y < 0)
            myBody.velocity = new Vector2(0, speed);
        else
            myBody.velocity = new Vector2(0, 0);
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(6f);
        Application.Quit();
    }
}
