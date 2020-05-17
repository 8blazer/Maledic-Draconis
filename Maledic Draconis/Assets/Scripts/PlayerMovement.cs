using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    List<string> inactiveObj = new List<string>();
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("moveSpeed") == 0)
        {
            PlayerPrefs.SetFloat("moveSpeed", 3);
        }
        if (PlayerPrefs.GetInt("maxHealth") == 0)
        {
            PlayerPrefs.SetInt("maxHealth", 100);
        }
        if (PlayerPrefs.GetInt("damage") == 0)
        {
            PlayerPrefs.SetInt("damage", 5);
        }
        if (PlayerPrefs.GetInt("critChance") == 0)
        {
            PlayerPrefs.SetInt("critChance", 10);
        }
        if (PlayerPrefs.GetInt("critDamage") == 0)
        {
            PlayerPrefs.SetInt("critDamage", 2);
        }
        int health = PlayerPrefs.GetInt("maxHealth");
        timer = PlayerPrefs.GetInt("swordDelay");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 velocity = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = velocity * PlayerPrefs.GetFloat("moveSpeed");
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
