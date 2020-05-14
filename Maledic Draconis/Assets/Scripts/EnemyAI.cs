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
    float timer = 3.1f;
    bool timerGoing = false;
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
        if (timerGoing)
        {
            timer += Time.deltaTime;
        }
        Vector2 chaseDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        if (chaseDirection.magnitude <= chaseTriggerDistance)
        {
            ChasePlayer();
            triggered = true;
            timer = 0;
        }
        else if (triggered == false && timer > 3)
        {
            triggered = true;
            Pace();
            timer = 0;
        }
        if (chaseDirection.magnitude > chaseTriggerDistance)
        {
            if (triggered == true && Random.Range(1,101) == 1)
            {
                triggered = false;
                timerGoing = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
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
}
