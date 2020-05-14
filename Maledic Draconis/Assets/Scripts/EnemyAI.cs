using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float chaseSpeed = 1.0f;
    public float chaseTriggerDistance = 5.0f;
    Vector3 startPosition;
    bool triggered = false;
    float timer = 0;
    System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 chaseDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        if (chaseDirection.magnitude <= chaseTriggerDistance)
        {
            ChasePlayer();
            triggered = true;
        }
        else if (triggered == false && chaseDirection.magnitude < 10)
        {
            triggered = true;
            Pace();
        }
        if (chaseDirection.magnitude > chaseTriggerDistance)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                triggered = false;
                timer = 0;
            }
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
        GetComponent<Rigidbody2D>().AddForce(new Vector2(rnd.Next(-15, 16), rnd.Next(-15, 16)));
    }
}
