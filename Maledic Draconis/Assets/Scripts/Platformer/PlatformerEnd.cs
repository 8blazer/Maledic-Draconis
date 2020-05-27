using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlatformerEnd : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && SceneManager.GetActiveScene().name == "Platformer")
        {
            SceneManager.LoadScene("TopDown2");
        }
        else if (collision.gameObject.name == "Player" && SceneManager.GetActiveScene().name == "Platformer2")
        {
            SceneManager.LoadScene("Boss");
        }
    }
}
