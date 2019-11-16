using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBound : MonoBehaviour {

    private float x_min, x_max, y_min, y_max;

    // Use this for initialization
    void Start()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        x_min = -bounds.x;
        x_max = bounds.x;
        y_min = -bounds.y;
        y_max = bounds.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        if (temp.x < x_min)
        {
            temp.x = x_min;
        }
        else if (temp.x > x_max)
        {
            temp.x = x_max;
        }
        else if (temp.y < y_min)
        {
            temp.y = y_min;
        }
        else if (temp.y > y_max)
        {
            temp.y = y_max;
        }
        transform.position = temp;
    }
}
