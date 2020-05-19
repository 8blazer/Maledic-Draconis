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
    float attackTimer;
    public int health;
    System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
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
        attackTimer += Time.deltaTime;
        Vector2 chaseDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        if (chaseDirection.magnitude <= saveManager.GetComponent<SaveManager>().enemyTriggerDistance)
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
        if (chaseDirection.magnitude > saveManager.GetComponent<SaveManager>().enemyTriggerDistance)
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
            LevelGen.enemyCount = LevelGen.enemyCount - 1;
            if (this.gameObject.name == "Slime(Clone)")
            {
                saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp + 1;
            }
            else if (this.gameObject.name == "Wolf(Clone)")
            {
                saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp + 2;
            }
            else if (this.gameObject.name == "Tree(Clone)")
            {
                saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp + 3;
            }
            else if (this.gameObject.name == "Kobold(Clone)")
            {
                saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp + 4;
            }
            else
            {
                saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp + 5;
            }
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
                if (saveManager.GetComponent<SaveManager>().critChance + saveManager.GetComponent<SaveManager>().startleCritChance > 99 || Random.Range(1, 101 - saveManager.GetComponent<SaveManager>().critChance + saveManager.GetComponent<SaveManager>().startleCritChance) == 1)
                {
                    health = health - (saveManager.GetComponent<SaveManager>().damage + saveManager.GetComponent<SaveManager>().critDamage + saveManager.GetComponent<SaveManager>().startleDamage + saveManager.GetComponent<SaveManager>().startleCritDamage);
                }
                else
                {
                    health = health - (saveManager.GetComponent<SaveManager>().damage + saveManager.GetComponent<SaveManager>().startleDamage) - Random.Range(-1, 2);
                }
            }
            else
            {
                if (saveManager.GetComponent<SaveManager>().critChance > 99 || Random.Range(1, 101 - saveManager.GetComponent<SaveManager>().critChance) == 1)
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
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.gameObject.name == "Slime(Clone)" && attackTimer > 3)
            {
                PlayerMovement.health = PlayerMovement.health - 7 + saveManager.GetComponent<SaveManager>().defense;
                attackTimer = 0;
            }
            else if (this.gameObject.name == "Wolf(Clone)" && attackTimer > 2)
            {
                PlayerMovement.health = PlayerMovement.health - 10 + saveManager.GetComponent<SaveManager>().defense;
                attackTimer = 0;
            }
            else if (this.gameObject.name == "Kobold(Clone)" && attackTimer > 1)
            {
                PlayerMovement.health = PlayerMovement.health - 10 + saveManager.GetComponent<SaveManager>().defense;
                attackTimer = 0;
            }
        }
    }
}
