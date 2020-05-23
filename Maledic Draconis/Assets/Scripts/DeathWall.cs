using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathWall : MonoBehaviour
{
    public GameObject player;
    bool timerGoing;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(120,0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, 0);
        if (timerGoing)
        {
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            timerGoing = true;
            if (timer > 1.5)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            timerGoing = false;
            timer = 0;
        }
    }
}
