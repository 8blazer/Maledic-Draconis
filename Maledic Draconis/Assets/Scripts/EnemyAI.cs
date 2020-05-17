using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    GameObject saveManager;
    public float chaseSpeed = 1.0f;
    Vector3 startPosition;
    bool triggered = false;
    bool startled = true;
    float timer = 3.1f;
    bool timerGoing = false;
    bool startledTimerGoing = false;
    float startledTimer;
    public int health;
    System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        if (PlayerPrefs.GetInt("chaseTriggerDistance") == 0)
        {
            PlayerPrefs.SetInt("chaseTriggerDistance", 5);
        }
        saveManager = GameObject.Find("GameMaster");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerGoing)
        {
            timer += Time.deltaTime;
        }
        if (startledTimerGoing)
        {
            startledTimer += Time.deltaTime;
            if (startledTimer > 1)
            {
                startled = false;
            }
        }
        Vector2 chaseDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        if (chaseDirection.magnitude <= PlayerPrefs.GetInt("chaseTriggerDistance"))
        {
            ChasePlayer();
            triggered = true;
            timer = 0;
            startledTimerGoing = true;
        }
        else if (triggered == false && timer > 3 && chaseDirection.magnitude < 10)
        {
            triggered = true;
            startled = true;
            Pace();
            timer = 0;
        }
        if (chaseDirection.magnitude > PlayerPrefs.GetInt("chaseTriggerDistance"))
        {
            if (triggered == true && Random.Range(1,101) == 1)
            {
                triggered = false;
                timerGoing = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        if (health < 1)
        {
            PlayerPrefs.SetInt("EXP", PlayerPrefs.GetInt("EXP") + 1);
            LevelGen.enemyCount = LevelGen.enemyCount - 1;
            Destroy(this.gameObject);
        }
    }
    void ChasePlayer()
    {
        Vector2 chaseDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
    void Pace()
    {
        int xForce = Random.Range(25, 40);
        int yForce = Random.Range(25, 40);
        if (Random.Range(1,3) == 1)
        {
            xForce = xForce * -1;
        }
        if (Random.Range(1, 3) == 1)
        {
            yForce = yForce * -1;
        }
        GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce, yForce));
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (startled)
            {
                if (PlayerPrefs.GetInt("critChance") + PlayerPrefs.GetInt("startledCritChance") > 99 || Random.Range(1, 101 - PlayerPrefs.GetInt("critChance") + PlayerPrefs.GetInt("startledCritChance")) == 1)
                {
                    health = health - saveManager.GetComponent<SaveManager>().damage + PlayerPrefs.GetInt("critDamage") + PlayerPrefs.GetInt("startleDamage") + PlayerPrefs.GetInt("startleCritDamage");
                }
                else
                {
                    health = health - saveManager.GetComponent<SaveManager>().damage + PlayerPrefs.GetInt("startledDamage") - Random.Range(-1, 2);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("critChance") > 99 || Random.Range(1, 101 - PlayerPrefs.GetInt("critChance")) == 1)
                {
                    health = health - (saveManager.GetComponent<SaveManager>().damage + saveManager.GetComponent<SaveManager>().critDamage);
                }
                else
                {
                    health = health - saveManager.GetComponent<SaveManager>().damage - Random.Range(-1, 2);
                }
            }
        }
    }
}
