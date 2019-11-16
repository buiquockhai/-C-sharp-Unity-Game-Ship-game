using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletLevelScript : MonoBehaviour {

    public static int currentLevel = 1;
    public static GameObject Bullet;
    public GameObject[] YellowBullet;
    public GameObject[] BlueBullet;
    public GameObject[] GreenBullet;

    // Update is called once per frame
    void Update () {
        if (PlayerController.currentTypeBullet == "YellowBullet")
        {
            Bullet = YellowBullet[currentLevel - 1];
        }
        else if (PlayerController.currentTypeBullet == "BlueBullet")
        {
            Bullet = BlueBullet[currentLevel - 1];
        }
        else
        {
            Bullet = GreenBullet[currentLevel - 1];
        }
    }
}
