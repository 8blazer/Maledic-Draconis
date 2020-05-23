using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlatformerMovement : MonoBehaviour
{
    GameObject saveManager;
    float timer = 0;
    public Slider healthSlider;
    public float jumpSpeed = 1.0f;
    static public int health;
    bool grounded = false;
    float regenTimer;
    float regenTimeNeeded;
    void Start()
    {
        saveManager = GameObject.Find("GameMaster");
        health = saveManager.GetComponent<SaveManager>().maxHealth;
        timer = saveManager.GetComponent<SaveManager>().swingSpeed;
        healthSlider.maxValue = health;
        if (saveManager.GetComponent<SaveManager>().healthRegen > 0)
        {
            regenTimeNeeded = 30 / saveManager.GetComponent<SaveManager>().healthRegen;
        }
    }
    void Update()
    {
        healthSlider.value = health;
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        if (moveX > 0)
        {
            moveX = moveX + 1;
        }
        else if (moveX < 0)
        {
            moveX = moveX - 1;
        }
        if (saveManager.GetComponent<SaveManager>().speedByMissingHealth)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * saveManager.GetComponent<SaveManager>().speed * saveManager.GetComponent<SaveManager>().maxHealth / health / 1.5f, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (saveManager.GetComponent<SaveManager>().speedByHealth)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * saveManager.GetComponent<SaveManager>().speed * health / saveManager.GetComponent<SaveManager>().maxHealth * 1.5f, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * saveManager.GetComponent<SaveManager>().speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        Debug.Log(GetComponent<Rigidbody2D>().velocity.x);
        if (timer < 30 && saveManager.GetComponent<SaveManager>().healthRegen > 0)
        {
            timer += Time.deltaTime;
            regenTimer += Time.deltaTime;
            if (regenTimer > regenTimeNeeded && health < saveManager.GetComponent<SaveManager>().maxHealth)
            {
                health++;
                regenTimer = 0;
            }
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            NotGrounded();
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
        }
        if (transform.position.y < -10)
        {
            health = 0;
        }
        if (health < 1)
        {
            saveManager.GetComponent<SaveManager>().ToJson();
            SceneManager.LoadScene("Lose");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Grounded();
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        Grounded();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        NotGrounded();
    }
    public void Grounded()
    {
        grounded = true;
    }

    public void NotGrounded()
    {
        grounded = false;
    }
}



