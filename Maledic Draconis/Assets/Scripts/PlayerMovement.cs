using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public GameObject saveManager;
    List<string> inactiveObj = new List<string>();
    float timer = 0;
    int health;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("GameMaster");
        health = saveManager.GetComponent<SaveManager>().maxHealth;
        timer = saveManager.GetComponent<SaveManager>().swingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 velocity = new Vector2(x, y);
        if (saveManager.GetComponent<SaveManager>().speedByMissingHealth)
        {
            GetComponent<Rigidbody2D>().velocity = velocity * saveManager.GetComponent<SaveManager>().speed * saveManager.GetComponent<SaveManager>().maxHealth / health / 2;
        }
        else if (saveManager.GetComponent<SaveManager>().speedByHealth)
        {
            GetComponent<Rigidbody2D>().velocity = velocity * saveManager.GetComponent<SaveManager>().speed * health / saveManager.GetComponent<SaveManager>().maxHealth * 2;
        }
        GetComponent<Rigidbody2D>().velocity = velocity * saveManager.GetComponent<SaveManager>().speed;
        foreach (GameObject square in LevelGen.squares)
        {
            if (Vector3.Distance(transform.position, square.transform.position) > 11 && square.tag == "Wall")
            {
                square.transform.gameObject.SetActive(false);
            }
            else
            {
                square.transform.gameObject.SetActive(true);
            }
        }
    }
}
