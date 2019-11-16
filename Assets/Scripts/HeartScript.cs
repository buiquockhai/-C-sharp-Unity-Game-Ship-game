using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour {

    private int numOfheart = 5;
    public static int currentHeart = 3;
    public Image[] Heart;
	// Update is called once per frame

	void Update () {
		for(int i = 0; i < numOfheart; i++)
        {
            if (i < currentHeart)
            {
                Heart[i].enabled = true;
            }
            else
            {
                Heart[i].enabled = false;
            }
        }
	}
}
