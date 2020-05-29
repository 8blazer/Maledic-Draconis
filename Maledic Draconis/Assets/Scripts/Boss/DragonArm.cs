using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonArm : MonoBehaviour
{
    Vector3 target;
    public GameObject player;
    float timer;
    int swinging = 0; // 0 = stationary, 1 = raising arm, 2 = lowering arm
    public GameObject saveManager;
    float attackTimer;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(transform.position.x, transform.position.y + 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3 && swinging == 0 && timer > 1 || swinging == 1)
        {
            timer = 0;
            RaiseArm();
        }
        else if (swinging == 2)
        {
            LowerArm();
        }
        else
        {
            timer += Time.deltaTime;
        }
        attackTimer += Time.deltaTime;
    }

    void RaiseArm()
    {
        swinging = 1;
        if (gameObject.name == "FrontRight")
        {
            transform.RotateAround(target, Vector3.forward, .3f);
            if (transform.eulerAngles.z > 70)
            {
                swinging = 2;
            }
        }
        else
        {
            transform.RotateAround(target, Vector3.back, .3f);
            if (transform.eulerAngles.z < 290)
            {
                swinging = 2;
            }
        }
    }

    void LowerArm()
    {
        if (gameObject.name == "FrontLeft")
        {
            transform.RotateAround(target, Vector3.forward, 2);
            if (transform.eulerAngles.z < 180 && transform.eulerAngles.z > 0)
            {
                swinging = 0;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            transform.RotateAround(target, Vector3.back, 2);
            if (transform.eulerAngles.z > 350)
            {
                swinging = 0;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cynthia" && swinging == 2 && attackTimer > .5f)
        {
            PlayerMovement.health = PlayerMovement.health - 45 + saveManager.GetComponent<SaveManager>().defense;
            attackTimer = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cynthia" && swinging == 2 && attackTimer > .5f)
        {
            PlayerMovement.health = PlayerMovement.health - 45 + saveManager.GetComponent<SaveManager>().defense;
            attackTimer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (saveManager.GetComponent<SaveManager>().critChance > 99 || Random.Range(1, 101 - saveManager.GetComponent<SaveManager>().critChance) == 1)
            {
                DragonHead.health = DragonHead.health - (saveManager.GetComponent<SaveManager>().damage + saveManager.GetComponent<SaveManager>().critDamage);
            }
            else
            {
                DragonHead.health = DragonHead.health - saveManager.GetComponent<SaveManager>().damage - Random.Range(-1, 2);
            }
        }
    }
}
