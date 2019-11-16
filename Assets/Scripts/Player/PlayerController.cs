using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject explor;

    public static string currentTypeBullet;
    private Rigidbody2D myBody;
    float speed = 7;

    void Awake()
    {
        HeartScript.currentHeart = 3;
        ScoreScript.Score = 0;
        BulletLevelScript.currentLevel = 1;
        currentTypeBullet = "YellowBullet";
        myBody = GetComponent<Rigidbody2D>();
    }

    int countScore = 5000;  //Tang mang khi Score dat 5k, 10k, 20k, 40k...
    void Update()
    {
        if (ScoreScript.Score > countScore)
        {
            countScore *= 2;
            if (HeartScript.currentHeart < 5)
                HeartScript.currentHeart++;
        }
    }

    void FixedUpdate()
    {
        //Move character
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;
        if (HeartScript.currentHeart > 0)
            myBody.velocity = new Vector2(h, v);

        //Shoot
        if (Input.GetKeyDown(KeyCode.Space) && HeartScript.currentHeart > 0)
        {
            Vector3 temp = transform.position;
            temp.y += 0.5f;
            switch (BulletLevelScript.currentLevel)
            {
                case 1:
                    {
                        Instantiate(BulletLevelScript.Bullet, temp, Quaternion.identity);
                    }
                    break;
                case 2:
                    {
                        Instantiate(BulletLevelScript.Bullet, temp, Quaternion.identity);
                    }
                    break;
                case 3:
                    {
                        Instantiate(BulletLevelScript.Bullet, temp, Quaternion.identity);
                    }
                    break;
                default:
                    {
                        GameObject Bullet;
                        Rigidbody2D bodyBullet;
                        for (int i = 0; i < BulletLevelScript.currentLevel; i++)
                        {
                            Bullet = Instantiate(BulletLevelScript.Bullet, temp, Quaternion.identity);
                            bodyBullet = Bullet.GetComponent<Rigidbody2D>();
                            float x = 0.8f * (i - BulletLevelScript.currentLevel / 2);
                            bodyBullet.velocity = new Vector2(x, 8);
                        }
                    }
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy" || target.tag == "Egg")
        {
            Explode();
            HeartScript.currentHeart--;
            if (BulletLevelScript.currentLevel > 1)
                BulletLevelScript.currentLevel--;

            if (HeartScript.currentHeart < 1)
            {
                StartCoroutine(dead());
            }
        }
        if (target.tag == "PowerUp")
        {
            ScoreScript.Score += 1000;
            if (BulletLevelScript.currentLevel < 5)
                BulletLevelScript.currentLevel++;
        }
        if (target.tag == "Thigh")
        {
            ScoreScript.Score += 50;
        }

        if (target.tag == "YellowBullet")
        {
            Destroy(target.gameObject);

            if (currentTypeBullet == "YellowBullet")    // update bullet level
            {
                if (BulletLevelScript.currentLevel < 5)
                {
                    BulletLevelScript.currentLevel++;
                }
                else
                {
                    BulletLevelScript.currentLevel = 5;
                }
            }
            else // no change level
            {
                currentTypeBullet = "YellowBullet";
            }
        }

        if (target.tag == "BlueBullet")
        {
            Destroy(target.gameObject);

            if (currentTypeBullet == "BlueBullet")    // update bullet level
            {
                if (BulletLevelScript.currentLevel < 5)
                {
                    BulletLevelScript.currentLevel++;
                }
                else
                {
                    BulletLevelScript.currentLevel = 5;
                }
            }
            else // no change level
            {
                currentTypeBullet = "BlueBullet";
            }
        }

        if (target.tag == "GreenBullet")
        {
            Destroy(target.gameObject);

            if (currentTypeBullet == "GreenBullet")    // update bullet level
            {
                if (BulletLevelScript.currentLevel < 5)
                {
                    BulletLevelScript.currentLevel++;
                }
                else
                {
                    BulletLevelScript.currentLevel = 5;
                }
            }
            else // no change level
            {
                currentTypeBullet = "GreenBullet";
            }
        }
    }

    IEnumerator dead()
    {
        Btn.Instance.showGameOverPanel();
        myBody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    void Explode()
    {
        
        Vector3 temp = transform.position;
        temp.z -= 5;
        GameObject exp = Instantiate(explor, temp, Quaternion.identity);
        Destroy(exp, 0.8f);
        //Bat tu 1s sau khi chet
        //
    }
}
