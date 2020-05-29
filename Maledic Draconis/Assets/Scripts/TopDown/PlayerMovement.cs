using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public GameObject saveManager;
    public Slider healthSlider;
    List<string> inactiveObj = new List<string>();
    float timer = 0;
    static public int health;
    float regenTimer;
    float regenTimeNeeded;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 velocity = new Vector2(x, y);
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
        if (saveManager.GetComponent<SaveManager>().speedByMissingHealth)
        {
            GetComponent<Rigidbody2D>().velocity = velocity * saveManager.GetComponent<SaveManager>().speed * saveManager.GetComponent<SaveManager>().maxHealth / health / 1.5f;
        }
        else if (saveManager.GetComponent<SaveManager>().speedByHealth)
        {
            GetComponent<Rigidbody2D>().velocity = velocity * saveManager.GetComponent<SaveManager>().speed * health / saveManager.GetComponent<SaveManager>().maxHealth * 1.5f;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = velocity * saveManager.GetComponent<SaveManager>().speed;
        }
        foreach (GameObject square in LevelGen.squares)
        {
            if (Vector3.Distance(transform.position, square.transform.position) > 11 && square.tag == "Wall")
            {
                square.transform.gameObject.SetActive(false);
            }
            else if (!LevelGen.open.Contains(square.transform.position.x + " " + square.transform.position.y) && square.transform.gameObject.activeSelf == false)
            {
                square.transform.gameObject.SetActive(true);
            }
        }
        if (health < 1)
        {
            LevelGen.open.Clear();
            LevelGen.squares.Clear();
            saveManager.GetComponent<SaveManager>().ToJson();
            SceneManager.LoadScene("Lose");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EBullet")
        {
            if (SceneManager.GetActiveScene().name == "TopDown" || SceneManager.GetActiveScene().name == "Platformer")
            {
                health = health - (10 - saveManager.GetComponent<SaveManager>().defense);
            }
            else if (SceneManager.GetActiveScene().name == "TopDown2" || SceneManager.GetActiveScene().name == "Platformer2")
            {
                health = health - (20 - saveManager.GetComponent<SaveManager>().defense);
            }
        }
    }
}
