using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    List<string> inactiveObj = new List<string>();
    float swordDelay;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 velocity = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = velocity * moveSpeed;
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
