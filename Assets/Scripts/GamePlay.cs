using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{

    [SerializeField] private GameObject Chicken_1_Red;
    [SerializeField] private GameObject Chicken_2_Blue;
    [SerializeField] private GameObject Boss_1_CK_UFO;
    [SerializeField] private GameObject Boss_2_Metal_Egg;

    private float speed = 5;
    private int randChicken = 0;
    private Vector3 location;
    private Rigidbody2D myBody;

    GameObject[] chicken = new GameObject[24];
    GameObject[] boss = new GameObject[3];
    Vector3 bounds;

    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
        location.z = -1;

        //CreateBoss();
        StartCoroutine(CreateChicken());
    }

    bool IsCreateBoss = false;
    bool canMove = false;
    void Update()
    {
        if (IsClearEnemy() && IsClearBoss())
        {
            if (IsCreateBoss)
            {
                IsCreateBoss = false;
                canMove = false;
                StartCoroutine(CreateChicken());
            }
            else
            {
                CreateBoss();
                IsCreateBoss = true;
            }
        }
    }

    //Chicken-----------------------------------
    float t = 2f;
    float speedMove = 1.1f;
    int numChickenDie = 0;
    IEnumerator CreateChicken()
    {
        randChicken = Random.Range(0, 2);
        switch (randChicken)
        {
            default:
            case 0: //Chicken di tu ben trai sang theo tung hang
                {
                    //Vi tri tao chicken ngoai man hinh
                    location.x = -bounds.x - 9.5f;
                    location.y = bounds.y - 1f;
                    Create();

                    //Move chicken ra man hinh
                    for (int i = 0; i < 24; i++)
                    {
                        if (i % 6 == 0)
                            yield return new WaitForSeconds(0.5f);
                        if (!chicken[i]) continue;
                        myBody = chicken[i].GetComponent<Rigidbody2D>();
                        myBody.velocity = new Vector2(speed * 0.75f, 0);
                    }

                    //Stop
                    yield return new WaitForSeconds(1.3f);
                    for (int i = 0; i < 24; i++)
                    {
                        if (i % 6 == 0)
                            yield return new WaitForSeconds(0.5f);
                        if (!chicken[i]) continue;
                        myBody = chicken[i].GetComponent<Rigidbody2D>();
                        myBody.velocity = new Vector2(0, 0);
                    }
                }
                break;
            case 1: //Chicken di tu trai phai sang zic zac
                {
                    location.x = bounds.x + 1f;
                    location.y = bounds.y - 0.8f;
                    Create();

                    //Move chicken ra man hinh
                    for (int k = 0; k < 9; k++)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (!chicken[i + j * 6]) continue;
                                myBody = chicken[i + j * 6].GetComponent<Rigidbody2D>();
                                myBody.velocity = new Vector2(-0.5f * speed, (2 * (k % 2) - 1) * speed);
                            }
                            yield return new WaitForSeconds(0.07f);
                        }
                        yield return new WaitForSeconds(0.02f);
                    }
                }
                break;
        }

        //Move chicken sau khi ra man hinh
        t = 2;
        speedMove = 1.1f;
        canMove = true;
        StartCoroutine(MoveChicken());
    }
    void Create()
    {
        randChicken = Random.Range(0, 2);
        GameObject type_Chicken;
        switch (randChicken)
        {
            default:
            case 1:
                type_Chicken = Chicken_1_Red;
                break;
            case 2:
                type_Chicken = Chicken_2_Blue;
                break;
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                chicken[i * 6 + j] = Instantiate(type_Chicken, location, Quaternion.identity);
                location.x += 1.5f;
            }
            location.x -= 9;
            location.y -= 1.2f;
        }
    }
    IEnumerator MoveChicken()
    {
        for (int i = 0; i < 24; i++)
        {
            if (i % 6 == 0)
                speedMove *= -1;
            if (!chicken[i]) continue;
            myBody = chicken[i].GetComponent<Rigidbody2D>();
            myBody.velocity = new Vector2(speedMove, 0);
        }
        speedMove *= -1;
        if (t <= speedMove * 2) t *= 2;
        yield return new WaitForSeconds(t);
        if (canMove) StartCoroutine(MoveChicken());
    }
    bool IsClearEnemy()
    {
        int count = 0;
        for (int i = 0; i < 24; i++)
            if (!chicken[i])
                count++;

        
        ScoreScript.Score += 100 * (count - numChickenDie);

        numChickenDie = count;
        if (numChickenDie == 24) return true;
        return false;
    }

    //Boss----------------------------------------
    int numBoss = 0;
    int numBossDie = 0;
    void CreateBoss()
    {
        randChicken = Random.Range(0, 2);
        
        switch (randChicken)
        {
            default:
            case 0: //3 UFO chicken
                {
                    numBoss = 3;                 
                    for (int i = 0; i < 3; i++)
                    {
                        location.x = Random.Range(-5, 5);
                        location.y = Random.Range(6.5f, 7.5f);
                        boss[i] = Instantiate(Boss_1_CK_UFO, location, Quaternion.identity);
                        
                    }
                }
                break;
            case 1: //1 metal egg
                {
                    numBoss = 1;
                    location.x = 0;
                    location.y = bounds.y + 2.5f;
                    boss[0] = Instantiate(Boss_2_Metal_Egg, location, Quaternion.identity);
                }
                break;
        }
    }
    bool IsClearBoss()
    {
        int count = 0;
        for (int i = 0; i < numBoss; i++)
            if (!boss[i])
                count++;


        ScoreScript.Score += 1000 * (count - numBossDie);
        numBossDie = count;
        if (numBossDie != numBoss) return false;
        return true;
    }
}
