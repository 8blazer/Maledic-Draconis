using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatEnemyAI : MonoBehaviour
{
    public GameObject player;
    GameObject saveManager;
    public GameObject feet;
    public float chaseSpeed = 1.0f;
    bool startled = true;
    float attackTimer;
    public int health;
    int xForce;
    int yForce;
    System.Random rnd = new System.Random();
    public float moveSpeed;
    public bool wanderRight;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("GameMaster");
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        Vector2 chaseDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        if (chaseDirection.magnitude <= saveManager.GetComponent<SaveManager>().enemyTriggerDistance)  //If the enemy is closer than the trigger distance
        {
            ChasePlayer();
        }
        else //If the enemy is further than the trigger distance
        {
            if (wanderRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        if (health < 1)
        {
            LevelGen.enemyCount = LevelGen.enemyCount - 1;
            if (this.gameObject.name == "Slime")
            {
                saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp + 1;
            }
            else if (this.gameObject.name == "Wolf")
            {
                saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp + 2;
            }
            else if (this.gameObject.name == "Tree")
            {
                saveManager.GetComponent<SaveManager>().exp = saveManager.GetComponent<SaveManager>().exp + 3;
            }
            else if (this.gameObject.name == "Kobold")
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
        Vector2 chaseDirection = new Vector2(player.transform.position.x - transform.position.x, GetComponent<Rigidbody2D>().velocity.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = new Vector2(chaseDirection.x * chaseSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (gameObject.name == "Wolf")
        {
            if (feet.GetComponent<EnemyFeet>().grounded == true && player.transform.position.y > transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 8);
            }
        }
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
            if (this.gameObject.name == "Slime" && attackTimer > 3)
            {
                PlatformerMovement.health = PlatformerMovement.health - 7 + saveManager.GetComponent<SaveManager>().defense;
                attackTimer = 0;
            }
            else if (this.gameObject.name == "Wolf" && attackTimer > 2)
            {
                PlatformerMovement.health = PlatformerMovement.health - 10 + saveManager.GetComponent<SaveManager>().defense;
                attackTimer = 0;
            }
            else if (this.gameObject.name == "Kobold" && attackTimer > 1)
            {
                PlatformerMovement.health = PlatformerMovement.health - 10 + saveManager.GetComponent<SaveManager>().defense;
                attackTimer = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (wanderRight)
            {
                wanderRight = false;
            }
            else
            {
                wanderRight = true;
            }
        }
    }
}
